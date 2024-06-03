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
        private QRDatabaseContext db = new QRDatabaseContext();
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

        public ActionResult CardView()
        {
            // Gán URL cố định trong code
            string fixedUrl = "https://github.com/Ho-Ngoc-Tai";

            QRGenerator generator = new QRGenerator();
            byte[] qrCodeBytes = generator.GenerateQRCode(fixedUrl);
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);
            ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;
           
            return View();
        }

        public ActionResult QrGenerate()
        {
            // Gán URL cố định trong code
            string fixedUrl = "https://github.com/Ho-Ngoc-Tai";

            QRGenerator generator = new QRGenerator();
            byte[] qrCodeBytes = generator.GenerateQRCode(fixedUrl);
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);
            ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;

            return View();
        }

        public ActionResult RedirectAfterScan(string userId)
        {
            // Xử lý logic sau khi người dùng quét mã QR và truy cập URL này
            ViewBag.UserId = userId;
            ViewBag.Message = "Bạn đã quét mã QR thành công.";
            return View();
        }
    }
}