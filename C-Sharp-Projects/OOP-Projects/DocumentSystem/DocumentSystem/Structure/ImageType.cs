using System;
using System.IO;

namespace DocumentSystem.Structure
{
    public class ImageType
    {
        private ImageType(string name)
        {
            this.Name = name;
        }

        public static ImageType Png { get { return new ImageType("png"); } }

        public static ImageType Gif { get { return new ImageType("gif"); } }

        public static ImageType Jpeg { get { return new ImageType("jpeg"); } }

        public string Name { get; private set; }

        public string ContentType { get { return "image/" + this.Name; } }

        public static ImageType CreateFromFileName(string fileName)
        {
            string fileExtension = new FileInfo(fileName).Extension;
            switch (fileExtension.ToLower())
            {
                case ".png":
                    return ImageType.Png;
                case ".gif":
                    return ImageType.Gif;
                case ".jpg":
                case ".jpeg":
                    return ImageType.Jpeg;
            }

            throw new NotSupportedException("Image type " + fileExtension + " is not supported.");
        }
    }
}
