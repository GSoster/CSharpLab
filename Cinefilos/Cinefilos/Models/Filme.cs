using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Cinefilos.Models
{

    

    public class Filme
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Categoria { get; set; }
        public string Diretor { get; set; }
        public string Sinopse { get; set; }
        
        //public Dictionary<string, int> Nota = new Dictionary<string, int>();
        public int NotaTemp{ get; set; }
        //foreign key
        public virtual ICollection<Comentario> Comentarios{ get; set; }

        //terminar amanhã<<<<<<<<<<<<<<<<<<<<<<<<

        //public int ComentarioId;
        //public ICollection<Comentario> Comentario{ get; set; }

    }
}