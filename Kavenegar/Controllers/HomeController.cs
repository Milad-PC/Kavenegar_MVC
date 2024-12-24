using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavenegarSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendTest()
        {
            ViewBag.Rslt = string.Empty;
            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(KavenegarRes.ApiKey);
                var result = api.Send("2000500666", "09117449565", "خدمات پیام کوتاه کاوه نگار");
                ViewBag.Rslt = result.Messageid.ToString();
            }
            catch (Kavenegar.Exceptions.ApiException ex)
            {
                // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                ViewBag.Rslt = "Message : " + ex.Message;
            }
            catch (Kavenegar.Exceptions.HttpException ex)
            {
                // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                ViewBag.Rslt = "Message : " + ex.Message;
            }
            return View();
        }
    }
}