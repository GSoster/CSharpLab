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

        //use of FLUENT API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }


    }
}
