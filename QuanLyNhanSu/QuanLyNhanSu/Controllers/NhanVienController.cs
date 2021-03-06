using System;
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
    public class NhanVienController : Controller
    {
        //khai báo db context để làm việc với database
        private QuanLyNhanSuDBContext db = new QuanLyNhanSuDBContext();

        // GET: NhanVien
        public ActionResult Index()
        {
            // trả về view index kèm theo list danh sách  nhân viên trong database
            return View(db.NhanViens.ToList());
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(string id)
        {
            //nếu id truyền vào bằng null thì trả về trang notfound
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // tìm kiếm nhân viên theo id được gửi lên
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                // trả về trang notfound nếu không tìm thấy dữ liệu
                return HttpNotFound();
            }
            // trả về view kèm theo thông tin của nhân viên
            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            // trả về view để cho người dùng nhập thông tin
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // quản lý phiên làm việc giữa client và sẻver
        [ValidateAntiForgeryToken]
        // nhận giá trị các thuộc tính từ client gửi lên
        public ActionResult Create([Bind(Include = "IDNV,TenNV,GioiTinh,Tuoi,SDT,Email,DiaChi,NgayVaolam")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNV,TenNV,GioiTinh,Tuoi,SDT,Email,DiaChi,NgayVaolam")] NhanVien nhanVien)
        {
            // nếu thỏa mãn ràng buộc dữ liệu
            if (ModelState.IsValid)
            {
                // add đối tượng gửi lên từ phía client vào db context
                db.Entry(nhanVien).State = EntityState.Modified;
                //lưu thay đổi vào database
                db.SaveChanges();
                // điều hướng về action index
                return RedirectToAction("Index");
            }
            // giữ nguyên view về create kèm thông báo lỗi
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
