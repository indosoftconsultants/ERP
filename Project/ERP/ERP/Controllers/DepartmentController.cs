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
using System.Text;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly INotyfService _notyf;

        public DepartmentController(ILogger<DepartmentController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getdata()
        {
            string baseurl = "http://192.168.10.34:81/api/" + "Department";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resstream = response.GetResponseStream();
            var value = new StreamReader(resstream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<DepartmentMasterModel>>(value);
            //return data;
            return View("Index", data);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentMasterModel collection)
        {
            try
            {
                #region
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("http://localhost:41621/api/Department");

                //    //HTTP POST
                //    var Dept = new  
                //        {
                //        DepartmentName = collection.DepartmentName
                //    };
                //    var postTask = client.PostAsJsonAsync<DepartmentMasterModel>(client.BaseAddress, Dept);
                //    postTask.Wait();

                //    var result = postTask.Result;
                //    if (result.IsSuccessStatusCode)
                //    {
                //        _notyf.Custom("Successfully Added", 5, "Green", "fa fa-check");
                //        return RedirectToAction("Index");
                //    }
                //}

                //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                ////collection.Insert(collection);                
                //return RedirectToAction(nameof(Index));
                #endregion
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/Department");

                    
                    var postTask =  client.PostAsJsonAsync<DepartmentMasterModel>(client.BaseAddress, collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        _notyf.Custom("Successfully Added", 5, "Green", "fa fa-check");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _notyf.Custom("Unable To Save", 5, "#FA5F55", "fa fa-pencil");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentMasterModel cobj = new DepartmentMasterModel();

            return View(cobj.GetAllDepartment().Find(c => c.Id == id));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentMasterModel collection)
         {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/Department");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<DepartmentMasterModel>(client.BaseAddress, collection);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        _notyf.Custom("Edited Successfully", 5, "#89CFF0", "fa fa-pencil");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _notyf.Custom("Unable To Edit", 5, "#FA5F55", "fa fa-pencil");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");              
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            DepartmentMasterModel cobj = new DepartmentMasterModel();

            return View(cobj.GetAllDepartment().Find(c => c.Id == id));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string a)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api");
                    var postTask = await client.DeleteAsync(client.BaseAddress + "/Department/" + id);
                    var jsonString = postTask.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer deSerializedResponse = new JavaScriptSerializer();
                    var data = deSerializedResponse.Deserialize<DeleteStatus>(jsonString);
                    if (data.isSuccess)
                    {
                        _notyf.Custom("Deleted Successfully", 5, "Green", "fa fa-trash");
                        RedirectToAction("Index");
                    }
                    else if (!data.isSuccess)
                    {
                        _notyf.Custom("This Department is in use", 5, "#FA5F55", "fa fa-exclamation-circle");
                        return RedirectToAction("Index");
                    }

                    //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
