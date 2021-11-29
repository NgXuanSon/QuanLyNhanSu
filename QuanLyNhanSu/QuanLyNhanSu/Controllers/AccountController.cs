﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;

namespace QuanLyNhanSu.Controllers
{
    public class AccountController : Controller
    {
        QuanLyNhanSuDBContext db = new QuanLyNhanSuDBContext();
        [AllowAnonymous]
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        //Nhận dữ liệu từ client gửi lên
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc, string returnUrl)
        {
            //Nếu vượt qua được Validation ở Account
            if (ModelState.IsValid)
            {
                var Models = db.Accounts.Where(m => m.UserName == acc.UserName && m.PassWord == acc.PassWord).ToList().Count();
                //Ktra thông tin đăng nhập
                if (Models == 1)
                {
                    //Set cookie
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View(acc);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //Kiểm tra xem returnUrl có thuộc hệ thống hay không
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}