using GraphQLBackend.Model;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQLBackend.GraphQL
{
    /// <summary>
    /// Queries are contained in one file
    /// </summary>
    public class Query
    {
        #region Authors
        [UseDbContext(typeof(BookStoreContext))]
        [UseProjection] // allows nesting
        public IQueryable<Author> GetAuthors([ScopedService] BookStoreContext bookStoreContext)
            => bookStoreContext.Authors;
       
        #endregion


        #region Books
        [UseDbContext(typeof(BookStoreContext))]
        [UseProjection]
        public IQueryable<Book> GetBooks([ScopedService] BookStoreContext bookStoreContext)
            => bookStoreContext.Books;
        
        #endregion
    }
}
