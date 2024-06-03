using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;

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
    }
}