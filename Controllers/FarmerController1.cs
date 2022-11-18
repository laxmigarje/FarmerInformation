using FarmerInformation.DAL;
using FarmerInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerInformation.Controllers
{
    public class FarmerController1 : Controller
    {
        private readonly IConfiguration configuration;
        FarmerDAL farmerdal;
        private object farmers;

        public FarmerController1(IConfiguration configuration)
        {
            this.configuration = configuration;
            farmerdal = new FarmerDAL(configuration);
        }

        // GET: FarmerController1
        public ActionResult FarmerRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FarmerRegister(Farmer farmer)
        {
            try
            {
                int res = farmerdal.FarmerRegister(farmer);
                if (res == 1)
                {
                    return RedirectToAction("FarmerLogin");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public IActionResult FarmerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FarmerLogin(Farmer farmers)
        {
            Farmer farmer = farmerdal.FarmerLogin(farmers);
            if (farmer.Password == farmer.Password)
            {
                HttpContext.Session.SetString("mobile_no", farmer.mobile_no);

               return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("FarmerLogin");

        }
    }
}

        // GET: FarmerController1/Details/5
/* public ActionResult Details(int id)
 {
     return View();
 }

 // GET: FarmerController1/Create
 public ActionResult Create()
 {
     return View();
 }

 // POST: FarmerController1/Create
 [HttpPost]
 [ValidateAntiForgeryToken]
 public ActionResult Create(IFormCollection collection)
 {
     try
     {
         return RedirectToAction(nameof(Index));
     }
     catch
     {
         return View();
     }
 }

 // GET: FarmerController1/Edit/5
 public ActionResult Edit(int id)
 {
     return View();
 }

 // POST: FarmerController1/Edit/5
 [HttpPost]
 [ValidateAntiForgeryToken]
 public ActionResult Edit(int id, IFormCollection collection)
 {
     try
     {
         return RedirectToAction(nameof(Index));
     }
     catch
     {
         return View();
     }
 }

 // GET: FarmerController1/Delete/5
 public ActionResult Delete(int id)
 {
     return View();
 }

 // POST: FarmerController1/Delete/5
 [HttpPost]
 [ValidateAntiForgeryToken]
 public ActionResult Delete(int id, IFormCollection collection)
 {
     try
     {
         return RedirectToAction(nameof(Index));
     }
     catch
     {
         return View();
     }
 }
}
}*/
