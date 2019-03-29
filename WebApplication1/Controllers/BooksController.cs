using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using LiteDB;
using System.IO;
using Newtonsoft.Json;




namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        
        // GET: Books
        
        public ActionResult List()
        {
            try {
                BooksRepository r = new BooksRepository();
               
                List<BookModel> myBooks = r.GetAll();
                int a = 1;
                foreach(BookModel book in myBooks) {

                    book.Numar = a++;

                }

                
                return View(myBooks);
            }
            catch (Exception ex) {

                return View("Error");
                
            }
            
        }

        [HttpGet]

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Add(BookModel book)
        {
            BooksRepository r = new BooksRepository();

            r.Add(book);
            //listaCarti.Add(book);

            return View("Succes");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            BooksRepository r = new BooksRepository();
            List<BookModel> myBooks = r.GetAll();
            var bks = myBooks.Where(b => b.Id == id).FirstOrDefault();

            

            
            return View(bks);
        }

        [HttpPost]

        public ActionResult Edit(BookModel book, int id) {
            BooksRepository r = new BooksRepository();

            r.Edit(book);

            return RedirectToAction("List");
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
           
                BooksRepository r = new BooksRepository();
                r.Delete(id);
            List<BookModel> myBooks = r.GetAll();

                //    foreach (BookModel book in listaCarti)
                //    {

                //        if (book.Id == id)
                //        {

                //            listaCarti.RemoveAt(id);
                //            return View("List", listaCarti);
                //        }

                //    }

                return View("List", myBooks);
            
        }

        public ActionResult Search() {

            return View();

        }

        [HttpPost]

        public ActionResult Search(SearchModel searchData)
        {
            BooksRepository r = new BooksRepository();

            List<BookModel> foundBooks = r.Search(searchData.Text);
            //listaCarti.Add(book);

            return View("List", foundBooks);
        }

        

            public ActionResult Download()
            {

                BooksRepository r = new BooksRepository();
                List<BookModel> myBooks = r.GetAll();
                string listString = "";
                foreach (var book in myBooks)
                {
                    string row = $"{ book.Name}, {book.AuthorName }, {book.ISBN}, {book.Year}\r\n";
                    listString = listString + row;
                }

                MemoryStream ms = new MemoryStream();
                StreamWriter sw = new StreamWriter(ms);
                sw.Write(listString);
                sw.Flush();
                ms.Position = 0;

                return File(ms, "application/force-download", "exportbiblioteca.csv");
            }

            public ActionResult Download2()
              {

            BooksRepository r = new BooksRepository();
            List<BookModel> myBooks = r.GetAll();
            string listString = JsonConvert.SerializeObject(myBooks);

            

            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.Write(listString);
            sw.Flush();
            ms.Position = 0;

            return File(ms, "application/force-download", "exportbiblioteca.json");
        }
        [HttpGet]
        public ActionResult Upload() {

            return View();

        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileContent) {

            string extension = Path.GetExtension(fileContent.FileName);

            if(extension.ToLower() == ".json") {
                StreamReader sr = new StreamReader(fileContent.InputStream);
                string body = sr.ReadToEnd();

                
                var books = JsonConvert.DeserializeObject<IEnumerable<BookModel>>(body).ToList();

                BooksRepository r = new BooksRepository();

                foreach (BookModel b in books)
                {
                    b.Id = 0;
                    r.Add(b);
                }
            }else if (extension.ToLower() == ".csv") {
                StreamReader sr = new StreamReader(fileContent.InputStream);
                BooksRepository r = new BooksRepository();
                while (!sr.EndOfStream) {
                    string row = sr.ReadLine();
                    string[] fields = row.Split(',', ';');
                    BookModel b = new BookModel
                    {

                        Name = fields[0],
                        AuthorName = fields[1],
                        ISBN = fields[2],
                        Year = int.Parse(fields[3])

                    };

                    r.Add(b);
                }

            }
           

            
            return RedirectToAction("List");
        }
    }
    }