using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewelly.Models;


namespace Jewelly.Areas.Admin.Controllers
{
    public class StoneMstController : Controller
    {
        JwelleyEntities db = new JwelleyEntities(); 
        // GET: Admin/Default
        public ActionResult StoneMst()
        {
            List<StoneMst> stone= db.StoneMst.ToList();
            return View(stone);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StoneMst p, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var stone1 = db.StoneMst.FirstOrDefault(row => row.Stone_ID == p.Stone_ID);
                if (stone1 == null)
                {
                    StoneMst stone = new StoneMst();
                    stone.Stone_Gm = decimal.Parse(form["Stone_Gm"]);
                    stone.Stone_Crt = decimal.Parse(form["Stone_Crt"]);
                    stone.Stone_Rate = decimal.Parse(form["Stone_Rate"]);
                    stone.Stone_Amt = decimal.Parse(form["Stone_Amt"]);
                    stone.Style_Code = p.Style_Code;
                    stone.StoneQlty_ID = p.StoneQlty_ID;
                    TempData["result"] = "Create StoneMst succesfully!";
                    db.StoneMst.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("StoneMst", "StoneMst");
                }
                else
                {
                    TempData["error"] = "Can't Create";
                    return RedirectToAction("Create", "StoneMst");

                }
            }
            return View();


        }

        public ActionResult Detail(int id)
        {
            StoneMst sto = db.StoneMst.Where(row => row.Stone_ID == id).FirstOrDefault();
            return View(sto);
        }
        public ActionResult Edit(int id)
        {
            StoneMst sto = db.StoneMst.Where(row => row.Stone_ID == id).FirstOrDefault();
            return View(sto);
        }

        [HttpPost]
        public ActionResult Edit(StoneMst pro)
        {
            var stoneMst = db.StoneMst.Where(row => row.Stone_ID == pro.Stone_ID).FirstOrDefault();
            //update
            if(stoneMst != null)
            {
                StoneMst st = db.StoneMst.Where(rows => rows.Stone_ID == pro.Stone_ID).FirstOrDefault();
                st.Stone_Gm = pro.Stone_Gm;
                st.Stone_Pcs = pro.Stone_Pcs;
                st.Stone_Crt = pro.Stone_Crt;
                st.Stone_Rate = pro.Stone_Rate;
                st.Stone_Amt = pro.Stone_Amt;
                st.Style_Code = pro.Style_Code;
                st.StoneQlty_ID = pro.StoneQlty_ID;
                TempData["result"] = "Edit StoneMst succesfully!";
                db.SaveChanges();
                return RedirectToAction("StoneMst");
            }
            else 
            {
                TempData["error"] = "Can't update";
                return RedirectToAction("StoneMst","StoneMst");
            }
        }
        public ActionResult Delete(int id)
        {
            StoneMst pro = db.StoneMst.Where(row => row.Stone_ID == id).FirstOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult Delete(int id, StoneMst pro)
        {
            StoneMst prodel = db.StoneMst.Where(row => row.Stone_ID == id).FirstOrDefault();
            db.StoneMst.Remove(prodel);
            TempData["result"] = "Delete StoneMst succesfully!";
            db.SaveChanges();
            return RedirectToAction("StoneMst");
        }

    }
}