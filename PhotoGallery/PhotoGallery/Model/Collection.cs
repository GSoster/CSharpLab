using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Model
{
    class Collection
    {
        public List<Photo> PhotoList{ get; set; }
        public List<Tag> TagList{ get; set; }
        public string Name { get; set; }//display name
        string _InternalName;
        public string InternalName
        {
            get { return _InternalName.ToLower(); }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                _InternalName = value.ToLower();
            }
        }
    }
}
