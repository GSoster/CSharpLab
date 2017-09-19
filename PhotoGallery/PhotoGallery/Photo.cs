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

        public string Path { get; }
        public BitmapFrame Image { get; set; }
        //Todo: Add above infos later
        //public Tag[] Tags;//list of tags that this photo has
        //public string fileName;//this one comes from the file
        //public string Title; //this one the user is responsible for creating


        public Photo(string path)
        {
            Path = path;
            _source = new Uri(path);
            Image = BitmapFrame.Create(_source);
        }

        public override string ToString()
        {
            return _source.ToString();
        }

    }
}
