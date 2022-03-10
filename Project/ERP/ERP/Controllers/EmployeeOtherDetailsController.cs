using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class EmployeeOtherDetailsController : Controller
    {
        // GET: EmployeeOtherDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeeOtherDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeOtherDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeOtherDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeOtherDetailsModel collection)
        {
            try
            {
                return RedirectToAction("~/Views/EmployeeBasicDetails/Create.cshtml");
                    
            }
            catch
            {
                return RedirectToAction("~/Views/EmployeeBasicDetails/Create.cshtml");
            }
        }

        // GET: EmployeeOtherDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeOtherDetailsController/Edit/5
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

        // GET: EmployeeOtherDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeOtherDetailsController/Delete/5
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
}
