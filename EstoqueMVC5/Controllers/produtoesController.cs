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
    public class produtoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: produtoes
        public ActionResult Index()
        {
            var produto = db.produto.Include(p => p.categoria).Include(p => p.fornecedor);
            return View(produto.ToList());
        }

        // GET: produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: produtoes/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "descricao");
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id", "descricao");
            return View();
        }

        // POST: produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,id_categoria,id_fornecedor,quantidade")] produto produto)
        {
            if (ModelState.IsValid)
            {
                db.produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categoria, "id", "descricao", produto.id_categoria);
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id", "descricao", produto.id_fornecedor);
            return View(produto);
        }

        // GET: produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "descricao", produto.id_categoria);
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id", "descricao", produto.id_fornecedor);
            return View(produto);
        }

        // POST: produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,id_categoria,id_fornecedor,quantidade")] produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "descricao", produto.id_categoria);
            ViewBag.id_fornecedor = new SelectList(db.fornecedor, "id", "descricao", produto.id_fornecedor);
            return View(produto);
        }

        // GET: produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produto produto = db.produto.Find(id);
            db.produto.Remove(produto);
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
