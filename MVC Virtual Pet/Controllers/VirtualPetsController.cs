using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Virtual_Pet.Models;

namespace MVC_Virtual_Pet.Controllers
{
    public class VirtualPetsController : Controller
    {
        private MVC_Virtual_PetContext db = new MVC_Virtual_PetContext();

        // GET: VirtualPets
        public ActionResult Index()
        {
            return View(db.VirtualPets.ToList());
        }

        // GET: VirtualPets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualPet virtualPet = db.VirtualPets.Find(id);
            if (virtualPet == null)
            {
                return HttpNotFound();
            }
            return View(virtualPet);
        }

        // GET: VirtualPets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VirtualPets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type,Hunger,Thirst")] VirtualPet virtualPet)
        {
            if (ModelState.IsValid)
            {
                db.VirtualPets.Add(virtualPet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(virtualPet);
        }

        // GET: VirtualPets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualPet virtualPet = db.VirtualPets.Find(id);
            if (virtualPet == null)
            {
                return HttpNotFound();
            }
            return View(virtualPet);
        }

        // POST: VirtualPets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,Hunger,Thirst")] VirtualPet virtualPet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(virtualPet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(virtualPet);
        }

        // GET: VirtualPets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualPet virtualPet = db.VirtualPets.Find(id);
            if (virtualPet == null)
            {
                return HttpNotFound();
            }
            return View(virtualPet);
        }

        // POST: VirtualPets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VirtualPet virtualPet = db.VirtualPets.Find(id);
            db.VirtualPets.Remove(virtualPet);
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
