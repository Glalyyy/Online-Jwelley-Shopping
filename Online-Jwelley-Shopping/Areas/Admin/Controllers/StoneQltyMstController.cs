using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelly.Models;

namespace Jewelly.Areas.Admin.Controllers
{
    public class StoneQltyMstController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();
        // GET: Admin/StoneQltyMst
        public ActionResult Stondqlt(string search= "")
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<StoneQltyMst> prod = db.StoneQltyMst.Where(x => x.StoneQlty.Contains(search)).ToList();
            return View(prod);

        }

        // GET: Admin/StoneQltyMst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/StoneQltyMst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/StoneQltyMst/Create
        [HttpPost]
        public ActionResult Create(StoneQltyMst q, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var qltyMst = db.StoneQltyMst.FirstOrDefault(row => row.StoneQlty_ID == q.StoneQlty_ID);
                if (qltyMst == null)
                {
                    StoneQltyMst stoneqlty = new StoneQltyMst();
                    stoneqlty.StoneQlty = form["StoneQlty"];
                    TempData["result"] = "Create StoneQltyMst succesfully!";
                    db.StoneQltyMst.Add(q);
                    db.SaveChanges();
                    return RedirectToAction("Stondqlt", "StoneQltyMst");
                }
                else
                {
                    TempData["error"] = "Can't Create";
                    return RedirectToAction("Create", "StoneQltyMst");

                }
            }
            return View();
        }

        // GET: Admin/StoneQltyMst/Edit/5
        public ActionResult Edit(int id)
        {
            StoneQltyMst pro = db.StoneQltyMst.Where(row => row.StoneQlty_ID == id).FirstOrDefault();
            return View(pro);
        }

        // POST: Admin/ProdMst/Edit/5
        [HttpPost]
        public ActionResult Edit(StoneQltyMst pr)
        {
            var pro = db.StoneQltyMst.Where(row => row.StoneQlty_ID == pr.StoneQlty_ID).FirstOrDefault();
            //update
            if (pro != null)
            {
                StoneQltyMst p = db.StoneQltyMst.Where(rows => rows.StoneQlty_ID == pro.StoneQlty_ID).FirstOrDefault();
                p.StoneQlty = pr.StoneQlty;
                TempData["result"] = "Edit StoneQltyMst succesfully!";
                db.SaveChanges();
                return RedirectToAction("Stondqlt","StoneQltyMst");
            }
            else
            {
                TempData["error"] = "Can't update";
                return RedirectToAction("StondQlt", "StoneQltyMst");
            }
        }


    }
}
