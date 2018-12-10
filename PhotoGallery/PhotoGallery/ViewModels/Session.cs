using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoGallery.Model;
/**
 *  Represents a instance of the program
 * */
namespace PhotoGallery.ViewModels
{
    public class Session
    {
        public Photo CurrentPhoto { get; set; }
        public string CurrentPath { get; set; }
        public Collection CurrentCollection { get; set; }
    }
}
