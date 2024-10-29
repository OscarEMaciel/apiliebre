using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepostory;
        public BookService(IBookRepository bookRepository) {
            _bookRepostory = bookRepository;
        }

        public List<BookDto> GetBooks() {
            
            var books =  _bookRepostory.GetBooks();

            return books.Select(book => new BookDto
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Price = book.Price,
                        Description = book.Description,
                        Category = book.Category,
                        ImageURL = book.ImageURL
                    })
                .ToList();
        }

        public int AddBook(BookDto bookDto)
        {
            return _bookRepostory.AddBook(new Book
                    {
                        Id = bookDto.Id,
                        Title = bookDto.Title,
                        Price = bookDto.Price,
                        Description = bookDto.Description,
                        Category = bookDto.Category,
                        ImageURL = bookDto.ImageURL
                    });
        }

        public void DeleteBook(int id)
        {
            _bookRepostory.DeleteBook(id);
        }

     
    }
}
