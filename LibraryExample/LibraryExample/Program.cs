using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryExample
{
    class Author
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime IssueDate { get; set; }
        public int Rating { get; set; }
        public Author Author { get; set; }
    }

    class Library
    {
        private Dictionary<Author, List<Book>> authorBooks = new Dictionary<Author, List<Book>>();

        public void LoadFromFile(string path)
        {

        }

        public void SaveToFile(string path)
        {

        }

        public List<Book> FindBookByAuthor(string name)
        {
            var author = new Author() { Name = name };

            var books = new List<Book>();
            if (authorBooks.ContainsKey(author))
            {
                books = authorBooks[author];
            }
            return books;
        }

        public Book FindBookByISBN(string isbn)
        {
            Book book = null;
            foreach (var authorBook in authorBooks)
            {
                foreach (var dictBook in authorBook.Value)
                {
                    if (dictBook.ISBN == isbn)
                    {
                        book = dictBook;
                        break;
                    }
                }
            }
            return book;
        }

        public void AddBook(Book book)
        {

        }

        public void AddAuthor(Author author)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
