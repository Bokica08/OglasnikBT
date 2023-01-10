using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oglasi.Models;

namespace Oglasi.Controllers
{
    public class OglasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Oglas
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.oglasi.ToList());
        }
        public ActionResult MoiOglasi()
        {
            return View(db.oglasi.ToList());
        }

        // GET: Oglas/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.oglasi.Find(id);
            if (oglas == null)
            {
                return HttpNotFound();
            }
            return View(oglas);
        }

        // GET: Oglas/Create
        public ActionResult Create()
        {
            ViewBag.marki = db.marki;

            return View();
        }
        public ActionResult getModel(string mid,string oglas)
        {
            List<Tip> modeli=db.modeli.Where(x=>x.modelName == mid).ToList();
            ViewBag.modelii = modeli;
            ViewBag.tip = oglas;

            return PartialView("ViewTipovi");
        }

        // POST: Oglas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Marka,Model,Nasolv,Godina,Cena,Boja,Opis,ime,telefon")] Oglas oglas,HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null) {
                    oglas.Images = new byte[image1.ContentLength];
                    image1.InputStream.Read(oglas.Images, 0, image1.ContentLength);
                        }
                oglas.userEmail=User.Identity.Name;
                db.oglasi.Add(oglas);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oglas);
        }

        // GET: Oglas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oglas oglas = db.oglasi.Find(id);
            ViewBag.marki = db.marki;
            if (oglas == null)
            {

                return HttpNotFound();
            }
            return View(oglas);
        }

        // POST: Oglas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Marka,Model,Nasolv,Godina,Cena,Boja,Opis,ime,telefon")] Oglas oglas, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {

            if (ModelState.IsValid)
            {

                 if (image1 != null)
                {
                    oglas.Images = new byte[image1.ContentLength];
                    image1.InputStream.Read(oglas.Images, 0, image1.ContentLength);
                }

                db.Entry(oglas).State = EntityState.Modified;


                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oglas);
        }

        private Oglas getOriginal(Oglas oglas)
        {
            return db.oglasi.Find(oglas.ID);
        }

        public ActionResult Delete(int id)
        {
            Oglas oglas = db.oglasi.Find(id);
            db.oglasi.Remove(oglas);
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
