using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using LiteDB;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult ListaAutori()
        {
            try
            {
                AuthorRepository r = new AuthorRepository();

                List<Authors> myAuthors = r.GetAll();
                return View(myAuthors);
            }
            catch (Exception ex)
            {

                return View("Error");

            }

        }

        [HttpGet]

        public ActionResult Addauthors()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Addauthors(Authors author)
        {
            AuthorRepository r = new AuthorRepository();

            r.Add(author);
            //listaCarti.Add(book);

            return View("Succes");
        }

        public ActionResult Edit(Authors author)
        {


            return View();
        }
        [HttpGet]

        public ActionResult Delete()
        {


            return View();
        }

        [HttpPost]

        //public ActionResult Delete( BookModel book)
        //{
        //    BooksRepository r = new BooksRepository();


        //    for (int i = 0; i <= listaCarti.Count - 1; i++)
        //    {

        //        if (book.Id == listaCarti[i].Id)
        //        {


        //            listaCarti.Remove(listaCarti[i]);
        //        }
        //    }


        //    return View("Succes2");
        //}

        public ActionResult Delete(int id)
        {

            //var b1 = listaCarti.Find(x => x.Id == id);
            //listaCarti.Remove(b1);

            AuthorRepository r = new AuthorRepository();
            r.Delete(id);
            List<Authors> myAutori = r.GetAll();

            //    foreach (BookModel book in listaCarti)
            //    {

            //        if (book.Id == id)
            //        {

            //            listaCarti.RemoveAt(id);
            //            return View("List", listaCarti);
            //        }

            //    }

            return View("ListaAutori", myAutori);

        }

        //public ActionResult AltAction(string nume, string autor) {


    }
}
    