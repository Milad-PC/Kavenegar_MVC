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
            var rslt = api.Send(sender : KavenegarRes.Sender , receptor : KavenegarRes.Reciver, message : "Hello Kavenegar");
            return View(rslt);
        }
        public ActionResult SendArray()
        {
            //تعداد گیرنده با تعداد پیام باید برابر باشد
            var rslt = api.SendArray(
                senders : new List<string> { KavenegarRes.Sender , KavenegarRes.Sender , KavenegarRes.Sender } ,
                receptors : new List<string> { KavenegarRes.Reciver, KavenegarRes.Reciver, KavenegarRes.Reciver },
                messages : new List<string> { "Hello Kavenegar 1" , "Hello Kavenegar 2" , "Hello Kavenegar 3" }
                );
            return View("Send",rslt.First());
        }
        public ActionResult Status()
        {
            var rslt = api.Status("1895418878");
            return View(rslt);
        }
        public ActionResult Select()
        {
            //استفاده از این متد نیاز به تنظیم IP در بخش تنظیمات امنیتی دارد 
            var rslt = api.Select("1895418878");
            return View("Send", rslt);
        }
        public ActionResult Receive()
        {
            //isread  = 0 : خوانده نشده - جدید
            //isread  = 1 : خوانده شده
            var rslt = api.Receive(KavenegarRes.Sender, 1);
            return View(rslt);
        }
        public string CountInbox()
        {
            DateTime start = DateTime.Now.AddMonths(-1);
            return api.CountInbox(startdate : start, enddate: DateTime.Now,linenumber: KavenegarRes.Sender).SumCount.ToString();
        }
        public ActionResult Lookup()
        {
            var rslt = api.VerifyLookup(KavenegarRes.Reciver, "1234", template: KavenegarRes.TemplateName);
            return View("Send", rslt);
        }
        public ActionResult TTS()
        {
            var rslt = api.CallMakeTTS("سلام", KavenegarRes.Reciver);
            return View("Send", rslt);
        }
        public string Info()
        {
            return api.AccountInfo().RemainCredit.ToString("n0");
        }
    }
}