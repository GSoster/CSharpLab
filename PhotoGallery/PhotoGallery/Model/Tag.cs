using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }//the name displayed to user
        public string Description { get; set; }
        string _InternalName; // it is used to sort/filter should always be lowercase
        public string InternalName {
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
