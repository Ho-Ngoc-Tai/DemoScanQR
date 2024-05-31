using QRScan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRScan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QrGenerate()
        {
            return View();
        }

        // Xử lý yêu cầu POST để tạo mã QR
        [HttpPost]
        public ActionResult QrGenerate(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                ViewBag.Message = "URL không được để trống.";
                return View("QrGenerate");
            }

            QRGenerator generator = new QRGenerator();
            byte[] qrCodeBytes = generator.GenerateQRCode(url);
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);
            ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;

            return View("QrGenerate");
        }
    }
}