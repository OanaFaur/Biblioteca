using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using LiteDB;

namespace WebApplication1
{
    public class AuthorRepository{

        public void Add(Authors author)
        {

            using (var db = new LiteDatabase(@"c:\DB\Biblioteca.db"))
            {

                var autori = db.GetCollection<Authors>("autori");

                autori.Insert(author);


            }

        }

        public List<Authors> GetAll()
        {

            using (var db = new LiteDatabase(@"c:\DB\Biblioteca.db"))
            {

                var autori = db.GetCollection<Authors>("autori");

                return autori.FindAll().ToList();


            }

        }

        public void Delete(int id)
        {

            var db = new LiteDatabase(@"c:\DB\Biblioteca.db");
            var autori = db.GetCollection<Authors>("autori");

            autori.Delete(id);



        }

    }


}
