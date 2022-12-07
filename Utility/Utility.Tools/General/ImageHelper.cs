
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class ImageHelper
{
    public static async System.Threading.Tasks.Task<IFormFile> ChangeImageAsync(IFormFile file,string watermarkAddress)
    {
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            var watermarkedStream = new MemoryStream();
            using (var img = Image.FromStream(stream))
            {
                using (var graphic = Graphics.FromImage(img))
                {
                    Bitmap water = new Bitmap(watermarkAddress);
                    Bitmap smallImage = new Bitmap(water,new Size(img.Width / 4,img.Width/4));
                    smallImage.MakeTransparent();

                    var font = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Bold, GraphicsUnit.Pixel);
                    var color = Color.FromArgb(128, 128, 128, 255);
                    var brush = new SolidBrush(color);
                    var point = new Point(10, 10);

                    //graphic.DrawString("kohmart.ir", font, brush, point);
                    graphic.DrawImage(smallImage, new Point(10, img.Height - smallImage.Height - 1));
                    img.Save(watermarkedStream, ImageFormat.Jpeg);
                    return new FormFile(watermarkedStream, 0, watermarkedStream.Length,"a","a"); 
                }
            }
        }
    }
}



