using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelly.Models;

namespace Jewelly.Areas.Admin.Controllers
{
    public class GoldKrtMstController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();

        // GET: Admin/GoldKrtMst
        public ActionResult Gold(string search="")
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<GoldKrtMst> prod = db.GoldKrtMst.Where(x=>x.Gold_Crt.Contains(search)).ToList();
            return View(prod);
        }

        // GET: Admin/GoldKrtMst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/GoldKrtMst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GoldKrtMst/Create
        [HttpPost]
        public ActionResult Create(GoldKrtMst e, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var prod = db.GoldKrtMst.FirstOrDefault(row => row.GoldType_ID == e.GoldType_ID);
                if (prod == null)
                {
                    GoldKrtMst stone = new GoldKrtMst();
                    stone.Gold_Crt = form["Gold_Crt"];
                    TempData["result"] = "Create Gold succesfully!";
                    db.GoldKrtMst.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("Gold", "GoldKrtMst");
                }
                else
                {
                    TempData["error"] = "Can't Create";
                    return RedirectToAction("Create", "GoldKrtMst");

                }
            }
            return View();
        }

        // GET: Admin/GoldKrtMst/Edit/5
        public ActionResult Edit(int id)
        {
            GoldKrtMst pro = db.GoldKrtMst.Where(row => row.GoldType_ID == id).FirstOrDefault();
            return View(pro);
           
        }

        // POST: Admin/GoldKrtMst/Edit/5
        [HttpPost]
        public ActionResult Edit(GoldKrtMst pro)
        {
            var gold = db.GoldKrtMst.Where(row => row.GoldType_ID == pro.GoldType_ID).FirstOrDefault();
            //update
            if (gold != null)
            {
                GoldKrtMst st = db.GoldKrtMst.Where(rows => rows.GoldType_ID == pro.GoldType_ID).FirstOrDefault();
                TempData["result"] = "Edit Gold succesfully!";
                st.Gold_Crt = pro.Gold_Crt;
                db.SaveChanges();

                return RedirectToAction("Gold", "GoldKrtMst");
            }
            else
            {
                TempData["error"] = "Can't update";
                return RedirectToAction("Gold", "GoldKrtMst");
            }
        }

        // GET: Admin/GoldKrtMst/Delete/5
       
    }
}
