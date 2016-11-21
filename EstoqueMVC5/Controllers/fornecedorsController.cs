using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstoqueMVC5;

namespace EstoqueMVC5.Controllers
{
    public class fornecedorsController : Controller
    {
        private Model1 db = new Model1();

        // GET: fornecedors
        public ActionResult Index()
        {
            var fornecedor = db.fornecedor.Include(f => f.cidade);
            return View(fornecedor.ToList());
        }

        // GET: fornecedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: fornecedors/Create
        public ActionResult Create()
        {
            ViewBag.id_cidade = new SelectList(db.cidade, "id", "descricao");
            return View();
        }

        // POST: fornecedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,id_cidade,email")] fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cidade = new SelectList(db.cidade, "id", "descricao", fornecedor.id_cidade);
            return View(fornecedor);
        }

        // GET: fornecedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cidade = new SelectList(db.cidade, "id", "descricao", fornecedor.id_cidade);
            return View(fornecedor);
        }

        // POST: fornecedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,id_cidade,email")] fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cidade = new SelectList(db.cidade, "id", "descricao", fornecedor.id_cidade);
            return View(fornecedor);
        }

        // GET: fornecedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fornecedor fornecedor = db.fornecedor.Find(id);
            db.fornecedor.Remove(fornecedor);
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
