using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_CodeFirstNewDatabaseSample
{
    class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }
}
