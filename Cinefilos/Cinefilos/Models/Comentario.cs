using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cinefilos.Models
{
    public class Comentario
    {
        [Key]
        public int ID { get; set; }
        public string Texto { get; set; }
        public string Email{ get; set; } //vira de ApplicationUser
        //public ApplicationUser User { get; set; }


    }
}