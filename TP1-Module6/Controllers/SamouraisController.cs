using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP1_Module6.BO;
using TP1_Module6.Data;
using TP1_Module6.Models;

namespace TP1_Module6.Controllers
{

    public class SamouraisController : Controller

    {
        private TP1_Module6Context db = new TP1_Module6Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamuraiViewModel samouraiViewModel = new SamuraiViewModel();
            samouraiViewModel.Armes = db.Armes.ToList();
            return View(samouraiViewModel);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamuraiViewModel samuraiViewModel)
        {
            if (ModelState.IsValid)
            {
                samuraiViewModel.Samurai.Arme = db.Armes.Find(samuraiViewModel.IdSelectedArme);
                db.Samourais.Add(samuraiViewModel.Samurai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            samuraiViewModel.Armes = db.Armes.ToList();
            return View(samuraiViewModel);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            SamuraiViewModel samuraiViewModel = new SamuraiViewModel();
            samuraiViewModel.Armes = db.Armes.ToList();
            samuraiViewModel.Samurai = samourai;
            samuraiViewModel.IdSelectedArme = samourai.Arme?.Id;
            return View(samuraiViewModel);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamuraiViewModel samuraiViewModel)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Include(x => x.Arme).SingleOrDefault(x => x.Id == samuraiViewModel.Samurai.Id);
                samourai.Nom = samuraiViewModel.Samurai.Nom;
                samourai.Force = samuraiViewModel.Samurai.Force;
                samourai.Arme = db.Armes.Find(samuraiViewModel.IdSelectedArme);
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            samuraiViewModel.Armes = db.Armes.ToList();
            return View(samuraiViewModel);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
