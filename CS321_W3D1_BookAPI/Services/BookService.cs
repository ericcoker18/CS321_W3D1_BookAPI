﻿using System.Collections.Generic;
using System.Linq;
using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.Services
{
    public class BookService : IBookService
    {

        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
            // TODO: keep a reference to the BookContext in _bookContext
        }

        public Book Add(Book book)
        {
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
            return book;

        }

        public Book Get(int id)
        {
            var book = _bookContext.Books.FirstOrDefault(book => book.Id == id);
            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books;
        }

        public Book Update(Book updatedBook)
        {
            // get the ToDo object in the current list with this id 
            var currentBook = _bookContext.Books.Find(updatedBook.Id);

            // return null if todo to update isn't found
            if (currentBook == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updatedBook);

            // update the todo and save
            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();
            return currentBook;
        }

        public void Remove(Book book)
        {
            _bookContext.Remove(book);
            _bookContext.SaveChanges();
        }

    }
}
