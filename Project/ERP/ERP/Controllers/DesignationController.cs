using AspNetCoreHero.ToastNotification.Abstractions;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ILogger<DesignationController> _logger;
        private readonly INotyfService _notyf;

        public DesignationController(ILogger<DesignationController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        // GET: DesignationController
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult getdata()
        {
            string baseurl = "http://192.168.10.34:81/api/" + "Designation";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resstream = response.GetResponseStream();
            var value = new StreamReader(resstream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<DesignationMasterModel>>(value);
            //return data;
            return View("Index", data);
        }

        // GET: DesignationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DesignationController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: DesignationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesignationMasterModel collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/Designation");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<DesignationMasterModel>(client.BaseAddress, collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        _notyf.Success("Successfully Added");
                        //TempData["Message"] = "Added Successfully";
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                //collection.Insert(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesignationController/Edit/5
        public ActionResult Edit(int id)
        {
            DesignationMasterModel cobj = new DesignationMasterModel();
            ViewBag.EditCountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetDepartment"));
            var list = cobj.GetAllDesignation().Find(c => c.Id == id);
            ViewBag.Id = list.DepartmentId;
            return View(cobj.GetAllDesignation().Find(c => c.Id == id));
            
        }

        // POST: DesignationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DesignationMasterModel collection)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/Designation");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<DesignationMasterModel>(client.BaseAddress, collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        _notyf.Custom("Edited Successfully", 5, "#89CFF0", "fa fa-pencil");
                        //_notyf.Custom("Edited Successfully", 10, "#4BB543 ", "fa fa-home");
                        //TempData["Message"] = "Successfully Edited";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _notyf.Custom("Unable To Edit", 5, "#FA5F55", "fa fa-pencil");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                //collection.Insert(collection);                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: DesignationController/Delete/5
        public ActionResult Delete(int id)
        {
            DesignationMasterModel cobj = new DesignationMasterModel();

            return View(cobj.GetAllDesignation().Find(c => c.Id == id));
        }

        // POST: DesignationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DesignationMasterModel collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api");
                    var postTask = await client.DeleteAsync(client.BaseAddress + "/Designation/" + id);
                    var jsonString = postTask.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer deSerializedResponse = new JavaScriptSerializer();
                    var data = deSerializedResponse.Deserialize<DeleteStatus>(jsonString);
                    if (data.isSuccess)
                    {
                        _notyf.Custom("Deleted Successfully", 5, "Green", "fa fa-trash");
                        RedirectToAction("Index");
                    }
                    else
                    {
                        _notyf.Custom("This State is in use", 5, "#FA5F55", "fa fa-exclamation-circle");
                        return RedirectToAction("Index");
                    }

                    //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return RedirectToAction("Index");
                }
                #region
                //var result = postTask.EnsureSuccessStatusCode();
                //if (result.IsSuccessStatusCode)
                //{
                //    _notyf.Custom("Deleted Successfully", 5, "Red", "fa fa-trash");
                //    RedirectToAction("Index");
                //}
                #endregion

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
