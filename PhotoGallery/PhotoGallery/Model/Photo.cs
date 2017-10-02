using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace PhotoGallery.Model
{
    /// <summary>
    ///     This class describes a single photo - its location, the image.
    /// </summary>
    public class Photo
    {
        
        public ImageSource Image { get; }        
        public string Extension { get; }
        public string Path { get; set; }
        private readonly Uri _source;
        public string FileName { get; }//this one comes from the file
        //Todo: Add below infos later
        public List<Tag> TagList { get; set; }//list of tags that this photo has

        //public string Name; //this one the user is responsible for creating


        public Photo(string path)
        {
            TagList = new List<Tag>();
            Path = path;
            _source = new Uri(path);
            Image = new BitmapImage(new Uri(path));
            FileName = System.IO.Path.GetFileName(path);
            Extension = System.IO.Path.GetExtension(path);
        }
        

        public override string ToString()
        {
            return _source.ToString();
        }

    }
}
