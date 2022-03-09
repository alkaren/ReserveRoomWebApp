using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReserveRoomMeetingWebApp.Models;

namespace ReserveRoomMeetingWebApp.Controllers
{
    public class tblT_ReservasiController : Controller
    {
        private ReserveModel db = new ReserveModel();
        

        // GET: tblT_Reservasi
        public ActionResult Index()
        {
            return View(db.tblT_Reservasi.ToList());
        }

        // GET: tblT_Reservasi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            if (tblT_Reservasi == null)
            {
                return HttpNotFound();
            }
            return View(tblT_Reservasi);
        }

        // GET: tblT_Reservasi/Create
        public ActionResult Create()
        {
            var items = db.tblM_Ruangan.ToList().Where(x => x.Status_FK == 2);
            if (items != null)
            {
                ViewBag.data = items;
            }
            var viewModel = new tblT_Reservasi
            {
                TanggalReservasi = DateTime.Today,
                CreatedBy = "Alka",
                CreatedDate = DateTime.Today,
                UpdatedBy = null,
                UpdatedDate = null
            };
            return View(viewModel);
        }

        // POST: tblT_Reservasi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reservasi_PK,Ruangan_FK,SubjectReservasi,TanggalReservasi,JamMulai,JamSelesai,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] tblT_Reservasi tblT_Reservasi)
        {
            if (ModelState.IsValid)
            {
                if(tblT_Reservasi.JamMulai > tblT_Reservasi.JamSelesai)
                {
                    TempData["message"] = "Jam Mulai Tidak Bisa Melebihi Jam Selesai";
                    return RedirectToAction("Index");
                }
                if (tblT_Reservasi.SubjectReservasi == null || tblT_Reservasi.SubjectReservasi == "")
                {
                    TempData["message"] = "Subject Reservasi Tidak Boleh Kosong";
                    return RedirectToAction("Index");
                }
                if (tblT_Reservasi.JamMulai == null)
                {
                    TempData["message"] = "JamMulai Tidak Boleh Kosong";
                    return RedirectToAction("Index");
                }
                if (tblT_Reservasi.JamSelesai == null)
                {
                    TempData["message"] = "JamSelesai Tidak Boleh Kosong";
                    return RedirectToAction("Index");
                }
                db.tblT_Reservasi.Add(tblT_Reservasi);
                tblM_Ruangan rm = db.tblM_Ruangan.Find(tblT_Reservasi.Ruangan_FK);
                rm.Status_FK = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblT_Reservasi);
        }

        // GET: tblT_Reservasi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            if (tblT_Reservasi == null)
            {
                return HttpNotFound();
            }
            return View(tblT_Reservasi);
        }

        // POST: tblT_Reservasi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Reservasi_PK,Ruangan_FK,SubjectReservasi,TanggalReservasi,JamMulai,JamSelesai,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] tblT_Reservasi tblT_Reservasi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblT_Reservasi).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblT_Reservasi);
        }

        // GET: tblT_Reservasi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            if (tblT_Reservasi == null)
            {
                return HttpNotFound();
            }
            return View(tblT_Reservasi);
        }

        // POST: tblT_Reservasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblT_Reservasi tblT_Reservasi = db.tblT_Reservasi.Find(id);
            db.tblT_Reservasi.Remove(tblT_Reservasi);
            tblM_Ruangan rm = db.tblM_Ruangan.Find(tblT_Reservasi.Ruangan_FK);
            rm.Status_FK = 2;
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
