
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BookingAppStore4.DALNew.Entities
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Redaction> Redactions { get; set; }

        public virtual DbSet<Brochure> Brochures { get; set; }

        public virtual DbSet<Gournal> Gournals { get; set; }

        public virtual DbSet<Publication> Publications { get; set; }



        public LibraryContext(string connectionString) : base("LibraryContext")
        {

        }
        public LibraryContext()
        {

        }

    }
}
