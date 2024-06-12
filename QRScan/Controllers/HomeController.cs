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
            // Gán URL của trang view NameCard.cshtml
            string viewUrl = Url.Action("index", "Home", null, Request.Url.Scheme);

            QRGenerator generator = new QRGenerator();
            byte[] qrCodeBytes = generator.GenerateQRCode(viewUrl);
            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);
            ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;

            var cards = new List<CardModel>
            {
                new CardModel { QRCodeImage = "~/Content/assets/icon.png", Title = "Card 1", Content = "Content 1" },
                new CardModel { QRCodeImage = "~/Content/assets/icon.png", Title = "Card 2", Content = "Content 2" },
                new CardModel { QRCodeImage = "~/Content/assets/icon.png", Title = "Card 3", Content = "Content 3" }
            };
            return View(cards);
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
            // Gán URL của trang view NameCard.cshtml
            string viewUrl = Url.Action("NameCard", "Home", null, Request.Url.Scheme);

            QRGenerator generator = new QRGenerator();
            byte[] qrCodeBytes = generator.GenerateQRCode(viewUrl);
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

            // Kiểm tra xem model có null không
            var model = new CardModel(); // Thay bằng cách khởi tạo model thích hợp
            model.QRCodeImage = "data:image/png;base64," + qrCodeBase64;
            ViewBag.QRCodeImage = model.QRCodeImage;

            return View();
        }

        //public ActionResult QrGenerate()
        //{
        //    // Gán URL cố định trong code
        //    string fixedUrl = "https://github.com/Ho-Ngoc-Tai";

        //    QRGenerator generator = new QRGenerator();
        //    byte[] qrCodeBytes = generator.GenerateQRCode(fixedUrl);
        //    string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);
        //    ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;

        //    return View();
        //}

        public ActionResult RedirectAfterScan(string userId)
        {
            // Xử lý logic sau khi người dùng quét mã QR và truy cập URL này
            ViewBag.UserId = userId;
            ViewBag.Message = "Bạn đã quét mã QR thành công.";
            return View();
        }

        //public ActionResult QrGenerate()
        //{
        //    // Gán URL của trang view NameCard.cshtml
        //    string viewUrl = Url.Action("NameCard", "Home", null, Request.Url.Scheme);

        //    QRGenerator generator = new QRGenerator();
        //    byte[] qrCodeBytes = generator.GenerateQRCode(viewUrl);
        //    string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);
        //    ViewBag.QRCodeImage = "data:image/png;base64," + qrCodeBase64;

        //    return View();
        //}

        public ActionResult NameCard()
        {
            return View();
        }

        public ActionResult Navbar()
        {
            return View();
        }
    }
}