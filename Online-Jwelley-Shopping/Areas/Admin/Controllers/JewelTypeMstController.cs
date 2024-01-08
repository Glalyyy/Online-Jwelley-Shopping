using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelly.Models;

namespace Jewelly.Areas.Admin.Controllers
{
    public class JewelTypeMstController : Controller
    {
        JwelleyEntities db = new JwelleyEntities();

        // GET: Admin/JewelTypeMst
        public ActionResult Jewel( string search="")
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMg = TempData["result"];
            }
            if (TempData["error"] != null)
            {
                ViewBag.ErrorMg = TempData["error"];
            }
            List<JewelTypeMst> prod = db.JewelTypeMst.Where(x => x.Jewellery_Type.Contains(search)).ToList();
            return View(prod);
        }

        // GET: Admin/JewelTypeMst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/JewelTypeMst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/JewelTypeMst/Create
        [HttpPost]
        public ActionResult Create(JewelTypeMst e, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var prod = db.JewelTypeMst.FirstOrDefault(row => row.ID == e.ID);
                if (prod == null)
                {
                    JewelTypeMst stone = new JewelTypeMst();
                    stone.Jewellery_Type = form["Jewellery_Type"];
                    TempData["result"] = "Create Jewellry succesfully!";
                    db.JewelTypeMst.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("Jewel", "JewelTypeMst");
                }
                else
                {
                    TempData["error"] = "Can't Create";
                    return RedirectToAction("Create", "JewelTypeMst");

                }
            }
            return View();
        }

        // GET: Admin/JewelTypeMst/Edit/5
        public ActionResult Edit(int id)
        {
            JewelTypeMst pro = db.JewelTypeMst.Where(row => row.ID == id).FirstOrDefault();
            return View(pro);
        }

        // POST: Admin/JewelTypeMst/Edit/5
        [HttpPost]
        public ActionResult Edit(JewelTypeMst pr)
        {
            var pro = db.JewelTypeMst.Where(row => row.ID == pr.ID).FirstOrDefault();
            //update
            if (pro != null)
            {
                JewelTypeMst p = db.JewelTypeMst.Where(rows => rows.ID == pro.ID).FirstOrDefault();
                p.Jewellery_Type = pr.Jewellery_Type;
                db.SaveChanges();
                TempData["result"] = "Edit Jewellry succesfully!";
                return RedirectToAction("Jewel");
            }
            else
            {
                TempData["error"] = "Can't update";
                return RedirectToAction("Jewel", "JewelTypeMst");
            }
        }

        // GET: Admin/JewelTypeMst/Delete/5
      
    }
}
