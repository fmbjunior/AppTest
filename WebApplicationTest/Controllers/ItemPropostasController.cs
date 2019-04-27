using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    public class ItemPropostasController : Controller
    {
        private Context db = new Context();

        // GET: ItemPropostas
        public ActionResult Index()
        {
            return View(db.ItensProposta.ToList());
        }

        // GET: ItemPropostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProposta itemProposta = db.ItensProposta.Find(id);
            if (itemProposta == null)
            {
                return HttpNotFound();
            }
            return View(itemProposta);
        }

        // GET: ItemPropostas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemPropostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Quantidade,Valor,Total")] ItemProposta itemProposta)
        {
            if (ModelState.IsValid)
            {
                db.ItensProposta.Add(itemProposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemProposta);
        }

        // GET: ItemPropostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProposta itemProposta = db.ItensProposta.Find(id);
            if (itemProposta == null)
            {
                return HttpNotFound();
            }
            return View(itemProposta);
        }

        // POST: ItemPropostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Quantidade,Valor,Total")] ItemProposta itemProposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemProposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemProposta);
        }

        // GET: ItemPropostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemProposta itemProposta = db.ItensProposta.Find(id);
            if (itemProposta == null)
            {
                return HttpNotFound();
            }
            return View(itemProposta);
        }

        // POST: ItemPropostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemProposta itemProposta = db.ItensProposta.Find(id);
            db.ItensProposta.Remove(itemProposta);
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
