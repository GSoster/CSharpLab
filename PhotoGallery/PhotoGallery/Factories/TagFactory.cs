using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Model;
namespace PhotoGallery.Factories
{
    public class TagFactory
    {
        public string Path { get; set; }

        public TagFactory(string path)
        {
            Path = path;
        }

        public List<Tag> GetTags()
        {
            var li = new List<Tag>();
            li.Add(new Tag() {Name = "Animal", Description = "Animal" });
            return li;
        }
    }
}
