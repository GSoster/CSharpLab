using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinefilos.Models;
using Microsoft.AspNet.Identity;

namespace Cinefilos.Controllers
{
    public class FilmesController : Controller
    {
        private FilmesContext db = new FilmesContext();
        private ApplicationDbContext userDb = new ApplicationDbContext();

        // GET: Filmes
        public ActionResult Index()
        {
            return View(db.Filmes.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Ano,Categoria,Diretor,Sinopse")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filmes/AddNota/5
        /* public ActionResult AddNota(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Filme filme = db.Filmes.Find(id);
             if (filme == null)
             {
                 return HttpNotFound();
             }
             return View(filme);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult AddNota([Bind(Include = "ID,Nome,Ano,Categoria,Diretor,Sinopse, NotaTemp")] Filme filme)        
         {
             if (ModelState.IsValid)
             {
                 string currentUserId = User.Identity.GetUserId();
                 ApplicationUser currentUser = userDb.Users.FirstOrDefault(x => x.Id == currentUserId);

                 filme.Nota.Add(currentUser.Email, filme.NotaTemp);
                 db.Entry(filme).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             return View(filme);
         }
         */

        // GET: Filmes/AddNota/5
        //movie ID
        public ActionResult AddComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment([Bind(Include = "ID,Nome,Ano,Categoria,Diretor,Sinopse, Comment")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = userDb.Users.FirstOrDefault(x => x.Id == currentUserId);
                //filme.Comentario.Email = currentUser.Email.ToString();                                
                filme.Nota.Add(currentUser.Email, filme.NotaTemp);
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }
        */


        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Ano,Categoria,Diretor,Sinopse")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }


        


        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
