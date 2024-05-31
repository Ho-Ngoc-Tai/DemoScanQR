using QRScan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRScan.Controllers
{
    public class QRCodeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(string url)
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