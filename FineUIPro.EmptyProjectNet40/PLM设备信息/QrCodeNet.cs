using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Drawing2D;

namespace MvcGuestBook.Common
{
    public class QrCodeNet
    {
        /// <summary>
        /// 生成二维码图片(中间无图片)详细源码链接:http://download.csdn.net/download/u012949335/10209428
        /// </summary>
        /// <param name="data">二维码里面的内容</param>
        public static string GetQrCodeDe(string data)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(data);
            string WebPath = "../PLM设备信息/QRCodeFile/" + DateTime.Now.ToString("yyyy-MM-dd");
            string DiskPath = HttpContext.Current.Server.MapPath(WebPath);
            if (!Directory.Exists(DiskPath))
            {
                Directory.CreateDirectory(DiskPath);
            }
            string FileName = DateTime.Now.ToString("HHmmss") + ".jpg";
            string FilePath = DiskPath + "/" + FileName;
            image.Save(FilePath);//写入图片文件中
            //HttpContext.Current.Response.Write(WebPath + "/" + FileName);
            //HttpContext.Current.Response.ContentType = "image/png";
            return WebPath + "/" + FileName;
        }


        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="data">二维码里面的内容</param>
        public static void GetQrCode(string data)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image image = qrCodeEncoder.Encode(data);
            //System.IO.MemoryStream MStream = new System.IO.MemoryStream();
            //image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);
            //MStream.Dispose();
            string WebPath = "FlexPaper/QRCodeFile/" + DateTime.Now.ToString("yyyy-MM-dd");
            string DiskPath = HttpContext.Current.Server.MapPath(WebPath);
            if (!Directory.Exists(DiskPath))
            {
                Directory.CreateDirectory(DiskPath);
            }
            string FileName = DateTime.Now.ToString("HHmmss") + ".jpg";
            string FilePath = DiskPath + "/" + FileName;
            Image QRImage = CombinImage(image, HttpContext.Current.Server.MapPath("~/Images/1.png"));//添加二维码中间的Log图片
            //System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
            //QRImage.Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);//写入缓存显示在页面
            //context.Response.BinaryWrite(MStream1.ToArray());
            //MStream1.Dispose();
            QRImage.Save(FilePath);//写入图片文件中
            HttpContext.Current.Response.Write(WebPath + "/" + FileName);
            //context.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "image/png";
        }

        /// <summary>
        /// 调用此函数后使此两种图片合并，类似相册，有个背景图，中间贴自己的目标图片  
        /// </summary>
        /// <param name="imgBack">粘贴的源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>
        /// <returns>图片</returns>
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg); //照片图片
            if (img.Height != 65 || img.Width != 65)
            {
                img = KiResizeImage(img, 65, 65, 0);
            }

            Graphics g = Graphics.FromImage(imgBack);
            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);
            //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);

            GC.Collect();
            return imgBack;
        }

        /// <summary>
        /// Resize图片      
        /// </summary>
        /// <param name="bmp">原始Bitmap </param>
        /// <param name="newW">新的宽度</param>
        /// <param name="newH">新的高度</param>
        /// <param name="Mode">保留着，暂时未用</param>
        /// <returns>处理以后的图片</returns>
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



    }
}