using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavenegarSample.Controllers
{
    public class HomeController : Controller
    {
        private Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(KavenegarRes.ApiKey);
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Send()
        {
            var rslt = api.Send(sender : KavenegarRes.Sender , receptor : "09117449565", message : "Hello Kavenegar");
            return View(rslt);
        }
        public ActionResult SendArray()
        {
            //تعداد گیرنده با تعداد پیام باید برابر باشد
            var rslt = api.SendArray(
                senders : new List<string> { KavenegarRes.Sender , KavenegarRes.Sender , KavenegarRes.Sender } ,
                receptors : new List<string> { "09117449565" , "09117449565" , "09117449565" },
                messages : new List<string> { "Hello Kavenegar 1" , "Hello Kavenegar 2" , "Hello Kavenegar 3" }
                );
            return View("Send",rslt.First());
        }
        public ActionResult Status()
        {
            var rslt = api.Status("1895418878");
            return View(rslt);
        }
    }
}