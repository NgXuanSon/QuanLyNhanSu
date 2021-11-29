﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class ChamCongController : Controller
    {
        private QuanLyNhanSuDBContext db = new QuanLyNhanSuDBContext();

        // GET: ChamCong
        public ActionResult Index()
        {
            return View(db.ChamCongs.ToList());
        }

        // GET: ChamCong/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // GET: ChamCong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChamCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenNV,SoNgayLam,SoNgayNghi,LyDoNghi")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.ChamCongs.Add(chamCong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chamCong);
        }

        // GET: ChamCong/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // POST: ChamCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenNV,SoNgayLam,SoNgayNghi,LyDoNghi")] ChamCong chamCong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamCong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chamCong);
        }

        // GET: ChamCong/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChamCong chamCong = db.ChamCongs.Find(id);
            if (chamCong == null)
            {
                return HttpNotFound();
            }
            return View(chamCong);
        }

        // POST: ChamCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChamCong chamCong = db.ChamCongs.Find(id);
            db.ChamCongs.Remove(chamCong);
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
