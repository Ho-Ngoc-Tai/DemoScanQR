using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.QrCode.Internal;

namespace QRScan.Models
{
    public class QRGenerator
    {
        public byte[] GenerateQRCode(string url)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 150,
                    Width = 150
                }
            };
            using (var bitmap = barcodeWriter.Write(url))
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        //public byte[] GenerateQRCode(string url)
        //{
        //    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        //    {
        //        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q))
        //        {
        //            using (QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData))
        //            {
        //                using (Bitmap bitmap = qrCode.GetGraphic(3))
        //                {
        //                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
        //                    {
        //                        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //                        return stream.ToArray();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
        
}