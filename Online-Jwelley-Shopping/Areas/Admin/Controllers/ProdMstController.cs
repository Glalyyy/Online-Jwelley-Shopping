using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelly.Models;

namespace Jewelly.Areas.Admin.Controllers
{
    public class ProdMstController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();

        // GET: Admin/ProdMst
        public ActionResult Prod( string search = "")
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<ProdMst> prod = db.ProdMst.Where(x => x.Prod_Type.Contains(search)).ToList();
            return View(prod);
        }

        // GET: Admin/ProdMst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProdMst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProdMst/Create
        [HttpPost]
        public ActionResult Create(ProdMst e, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var prod = db.ProdMst.FirstOrDefault(row => row.Prod_ID == e.Prod_ID);
                if (prod == null)
                {
                    ProdMst stone = new ProdMst();
                    stone.Prod_Type = form["Prod_Type"];
                    TempData["result"] = "Create Product succesfully!";
                    db.ProdMst.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("Prod", "ProdMst");
                }
                else
                {
                    TempData["error"] = "Can't Create";
                    return RedirectToAction("Create", "ProdMst");

                }
            }
            return View();
        }

        // GET: Admin/ProdMst/Edit/5
        public ActionResult Edit(int id)
        {
            ProdMst pro = db.ProdMst.Where(row => row.Prod_ID == id).FirstOrDefault();
            return View(pro);
        }

        // POST: Admin/ProdMst/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdMst pr)
        {
            var pro = db.ProdMst.Where(row => row.Prod_ID == pr.Prod_ID).FirstOrDefault();
            //update
            if (pro != null)
            {
                ProdMst p = db.ProdMst.Where(rows => rows.Prod_ID == pro.Prod_ID).FirstOrDefault();
                p.Prod_Type= pr.Prod_Type;
                TempData["result"] = "Edit Jewellry succesfully!";
                db.SaveChanges();
                return RedirectToAction("Prod");
            }
            else
            {
                TempData["error"] = "Can't update";
                return RedirectToAction("Prod", "ProdMst");
            }
        } 

        // GET: Admin/ProdMst/Delete/5
       
    }
}
