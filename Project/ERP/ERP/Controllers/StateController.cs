using AspNetCoreHero.ToastNotification.Abstractions;
using ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class StateController : Controller
    {
        private readonly ILogger<StateController> _logger;
        private readonly INotyfService _notyf;

        public StateController(ILogger<StateController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }


        // GET: StateController
        public ActionResult Index()
        {
            //StateModel obj = new StateModel();
            //ModelState.Clear();
            // var List = obj.GetAllState();

            //return View(obj.GetAllState());
            return View();
        }

        [HttpGet]
        public ActionResult getdata()
        {
            //StateModel obj = new StateModel();
            //var List = obj.GetAllState();
            ////return View("Index",List);
            //return View();
            string baseurl = "http://192.168.10.34:81/api/" + "State";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resstream = response.GetResponseStream();
            var value = new StreamReader(resstream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<StateModel>>(value);
            //return data;
            return View("Index", data);
        }

            // GET: StateController/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            
           ViewBag.CountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetCountry"));
           
            
            return View();
        }

       

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateModel collection)
        {
            #region
            //try
            //{

            //    collection.Insert(collection);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            #endregion
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/State");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<StateModel>(client.BaseAddress, collection);
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

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            StateModel cobj = new StateModel();
            ViewBag.EditCountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetCountry"));
            var list = cobj.GetAllState().Find(c => c.Id == id);
            ViewBag.Id = list.CountryId;
            return View(cobj.GetAllState().Find(c => c.Id == id));
            
        }

        // POST: StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StateModel collection)
        {
            try
            {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/State");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<StateModel>(client.BaseAddress, collection);
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

        // GET: StateController/Delete/5
        public ActionResult Delete(int id, string a)
        {
            StateModel cobj = new StateModel();

            return View(cobj.GetAllState().Find(c => c.Id == id));
        }

        // POST: StateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api");
                    var postTask = await client.DeleteAsync(client.BaseAddress + "/State/" + id);
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
