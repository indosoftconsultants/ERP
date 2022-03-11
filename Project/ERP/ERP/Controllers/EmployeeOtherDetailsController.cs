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
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.DepartmentList = DatatableToClass.CommonMethod.ConvertToList<DepartmentMasterModel>(Utility.GetData("List_GetDepartment"));
            ViewBag.DesignationList = DatatableToClass.CommonMethod.ConvertToList<DesignationMasterModel>(Utility.GetData("List_GetDesignation"));
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
            ViewBag.DepartmentList = DatatableToClass.CommonMethod.ConvertToList<DepartmentMasterModel>(Utility.GetData("List_GetDepartment"));
            ViewBag.DesignationList = DatatableToClass.CommonMethod.ConvertToList<DesignationMasterModel>(Utility.GetData("List_GetDesignation"));
            return View();
        }

        // POST: EmployeeOtherDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeOtherDetailsModel collection)
        {
            try
            {
                //return View("Create","EmployeeBasicDetails");
                return RedirectToAction("Create", "EmployeeBasicDetails");
            }
            catch
            {
                return RedirectToAction("Create", "EmployeeBasicDetails");
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
