using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class TodoTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TodoTeams
        public ActionResult Index()
        {
            return View(db.TodoTeams.ToList());
        }

        // GET: TodoTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTeam todoTeam = db.TodoTeams.Find(id);
            if (todoTeam == null)
            {
                return HttpNotFound();
            }
            return View(todoTeam);
        }

        // GET: TodoTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoTeams/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,Name,Description,IsDone")] TodoTeam todoTeam)
        {
            if (ModelState.IsValid)
            {
                db.TodoTeams.Add(todoTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoTeam);
        }

        // GET: TodoTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTeam todoTeam = db.TodoTeams.Find(id);
            if (todoTeam == null)
            {
                return HttpNotFound();
            }
            return View(todoTeam);
        }

        // POST: TodoTeams/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,Name,Description,IsDone")] TodoTeam todoTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoTeam);
        }

        // GET: TodoTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTeam todoTeam = db.TodoTeams.Find(id);
            if (todoTeam == null)
            {
                return HttpNotFound();
            }
            return View(todoTeam);
        }

        // POST: TodoTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoTeam todoTeam = db.TodoTeams.Find(id);
            db.TodoTeams.Remove(todoTeam);
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
