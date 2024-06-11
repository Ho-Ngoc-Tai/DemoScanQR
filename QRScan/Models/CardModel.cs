using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRScan.Models
{
    public class CardModel
    {
        public string QRCodeImage { get; set; }
        // Các thuộc tính khác của card, ví dụ:
        public string Title { get; set; }
        public string Content { get; set; }
    }
}