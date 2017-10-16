using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery.Model
{
    public class Collection : ObservableCollection<Photo>
    {        
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
                _InternalName = value.ToLower().Replace(" ","");//no spaces or upper case letters allowed
            }
        }


        public Collection(string name = "unamed collection")
        {
            Name = name;
            InternalName = name;
            TagList = new List<Tag>();            
        }

        public int GetCollectionSize()
        {
            return this.Count;            
        }
        

    }
}
