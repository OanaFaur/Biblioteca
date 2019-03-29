using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class BooksRepository{

        public void Add(BookModel book) {

            using (var db = new LiteDatabase(@"c:\DB\Biblioteca.db")) {

                var books = db.GetCollection<BookModel>("books");

                books.Insert(book);
                

            }

        }

        public List<BookModel> GetAll() {

            using (var db = new LiteDatabase(@"c:\DB\Biblioteca.db"))
            {

                var books = db.GetCollection<BookModel>("books");

                return books.FindAll().ToList();


            }

        }

        public void Delete(int id)
        {

            var db = new LiteDatabase(@"c:\DB\Biblioteca.db");
            var books = db.GetCollection<BookModel>("books");

            books.Delete(id);
            


        }

        public List<BookModel> Search(string text) {

            var db = new LiteDatabase(@"c:\DB\Biblioteca.db");
            var books = db.GetCollection<BookModel>("books");

            return books.Find(Query.Or(Query.Contains("Name", text), Query.Contains("AuthorName", text))).ToList();

        }

        public void Edit(BookModel book)
        {

            var db = new LiteDatabase(@"c:\DB\Biblioteca.db");
            var books = db.GetCollection<BookModel>("books");
            
            books.Update(book);

        }

    }
}
        
    