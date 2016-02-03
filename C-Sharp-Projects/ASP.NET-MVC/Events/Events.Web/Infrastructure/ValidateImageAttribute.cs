namespace Events.Web.Infrastructure
{
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web;

    public class ValidateImageAttribute : ValidationAttribute
    {
        private const int MaxSize = 100*1024;
        private const int MinPixels = 100;
        private const int MaxPixels = 400;
        private static readonly ImageFormat[] AllowedFormats = { ImageFormat.Gif, ImageFormat.Png, ImageFormat.Jpeg };

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null || file.ContentLength > MaxSize)
            {
                return false;
            }

            try
            {
                using (var image = Image.FromStream(file.InputStream))
                {
                    var isValid = AllowedFormats.Contains(image.RawFormat) &&
                                  image.Height >= MinPixels && image.Height <= MaxPixels &&
                                  image.Width >= MinPixels && image.Height <= MaxPixels;
                    return isValid;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}