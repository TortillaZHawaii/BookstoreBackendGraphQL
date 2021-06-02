
using GraphQLBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQLBackend
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        // not used with pooling
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(@"DataSource=C:\bookstore.db");

        /// <summary>
        /// Constructor required for pooling
        /// </summary>
        /// <param name="options"></param>
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        { }
    }

}
