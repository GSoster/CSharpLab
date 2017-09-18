using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoGallery
{
    /// <summary>
    ///     This class describes a single photo - its location, the image.
    /// </summary>
    public class Photo
    {
        private readonly Uri _source;

        public string Source { get; }
        public BitmapFrame Image { get; set; }



        public Photo(string path)
        {
            Source = path;
            _source = new Uri(path);
            Image = BitmapFrame.Create(_source);
        }

        public override string ToString()
        {
            return _source.ToString();
        }

    }
}
