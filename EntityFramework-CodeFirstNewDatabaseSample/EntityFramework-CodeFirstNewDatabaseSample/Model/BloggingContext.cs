using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EntityFramework_CodeFirstNewDatabaseSample
{
    class BloggingContext : DbContext
    {
        /**
         * DbContext:
         * context represents a session with the database, allowing us to query and save data.
         * */
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
