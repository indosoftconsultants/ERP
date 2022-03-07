using AspNetCoreHero.ToastNotification.Abstractions;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class EmployeeBasicDetailsController : Controller
    {
        private readonly ILogger<EmployeeBasicDetailsController> _logger;
        private readonly INotyfService _notyf;

        public EmployeeBasicDetailsController(ILogger<EmployeeBasicDetailsController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        // GET: EmployeeBasicDetailsController
        public ActionResult Index()
        {

            return View();
        }
      
        // GET: EmployeeBasicDetailsController/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: EmployeeBasicDetailsController/Create
        public ActionResult Create()
        {
            ViewBag.List_GetNamePrefix = DatatableToClass.CommonMethod.ConvertToList<NamePrefixModel>(Utility.GetData("List_GetNamePrefix"));
            ViewBag.List_GetMaritialStatus = DatatableToClass.CommonMethod.ConvertToList<MaritialStatusModel>(Utility.GetData("List_GetMaritialStatus"));
            ViewBag.List_GetGender = DatatableToClass.CommonMethod.ConvertToList<GenderModel>(Utility.GetData("List_GetGender"));
            ViewBag.List_GetEducation = DatatableToClass.CommonMethod.ConvertToList<EducationModel>(Utility.GetData("List_GetEducation"));
            ViewBag.CountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetCountry"));
            ViewBag.StateList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetState"));
            ViewBag.CityList = DatatableToClass.CommonMethod.ConvertToList<CityModel>(Utility.GetData("List_GetCity"));
            return View();
        }

        // POST: EmployeeBasicDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public   ActionResult Create(EmployeeBasicDetailsModel emp)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/EmployeeBasicDetails");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<EmployeeBasicDetailsModel>(client.BaseAddress, emp);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        _notyf.Success("Successfully Added");
                        return RedirectToAction("create");
                    }
                    else
                    {
                        _notyf.Custom("Unable To Save", 5, "#FA5F55", "fa fa-exclamation-circle");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return RedirectToAction("create");
                //return View("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeBasicDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeBasicDetailsController/Edit/5
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

        // GET: EmployeeBasicDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeBasicDetailsController/Delete/5
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
