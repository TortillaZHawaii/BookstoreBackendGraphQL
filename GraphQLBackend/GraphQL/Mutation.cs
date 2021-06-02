using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GraphQLBackend.Model;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQLBackend.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(BookStoreContext))]
        public async Task<Book> AddBook([ScopedService] BookStoreContext bookStoreContext,
            int authorId, string title)
        {
            var newBook = new Book()
            {
                AuthorId = authorId,
                Title = title,
            };

            await bookStoreContext.Books.AddAsync(newBook);
            await bookStoreContext.SaveChangesAsync();
            
            return newBook;
        }

        [UseDbContext(typeof(BookStoreContext))]
        public async Task<Author> AddAuthor([ScopedService] BookStoreContext bookStoreContext,
            string name, Book[] books=null) // adding books doesn't work rn
        {
            var newAuthor = new Author()
            {
                Name = name,
            };

            await bookStoreContext.Authors.AddAsync(newAuthor);
            if(books is not null)
            {
                await bookStoreContext.Books.AddRangeAsync(books);
            }
            await bookStoreContext.SaveChangesAsync();

            return newAuthor;
        }
    }
}
