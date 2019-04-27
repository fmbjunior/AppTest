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
    public class PropostasController : Controller
    {
        private Context db = new Context();

        // GET: Propostas
        public ActionResult Index()
        {
            return View(db.Propostas.ToList());
        }

        private List<SelectListItem> GetClientLListItem()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var listClientes = db.Clientes.ToList();

            foreach (var item in listClientes)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Nome,
                    Value = item.Id.ToString()
                });
            }

            return items;
        }

        private List<SelectListItem> GetFornecedoresListItem()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            var listFornecedores = db.Fornecedores.ToList();

            foreach (var item in listFornecedores)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Nome,
                    Value = item.Id.ToString()
                });
            }

            return items;
        }

        // GET: Propostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // GET: Propostas/Create
        public ActionResult Create()
        {
            PropostaViewModel propostaViewModel = new PropostaViewModel
            {
                ListItemsClientes = GetClientLListItem(),
                ListItemsFornecedores = GetFornecedoresListItem(),
                ItensProposta = new List<ItemProposta>(),
                ItemProposta = new ItemProposta()
            };

            return View(propostaViewModel);
        }

        public ActionResult AddItem(PropostaViewModel propostaViewModel)
        {

            return View(propostaViewModel);
        }

        // POST: Propostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoProposta")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                var propostasDay = db.Propostas.Where(x => x.DataCadastro == DateTime.Now).ToList();

                proposta.CodigoProposta = DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + propostasDay.Count + 1;
                db.Propostas.Add(proposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proposta);
        }

        // GET: Propostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // POST: Propostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoProposta")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proposta);
        }

        // GET: Propostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Propostas.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // POST: Propostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposta proposta = db.Propostas.Find(id);
            db.Propostas.Remove(proposta);
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
