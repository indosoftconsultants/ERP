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
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly INotyfService _notyf;

        public CityController(ILogger<CityController> logger, INotyfService notyf)          
        {                                                                                   
            _logger = logger;                                                               
            _notyf = notyf;                                                                 
        }                                                                                   
                                                                                            
        // GET: CityController                                                              
        public ActionResult Index()
        {
           
            
            return View();
        }

        [HttpGet]
        public ActionResult getdata()
        {           
            string baseurl = "http://192.168.10.34:81/api/" + "City";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resstream = response.GetResponseStream();
            var value = new StreamReader(resstream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<CityModel>>(value);
            //return data;
            return View("Index", data);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewBag.CountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetCountry"));
            ViewBag.StateList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetState"));
            return View();
        }


        public ActionResult Load()//for loading ddl on click not working
        {
            ViewBag.CountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("CountryList"));
            ViewBag.StateList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("StateList"));
            return View();
        }


        public ActionResult Cascading(int id)
        {
            TempData["CountryId"] = id;
            return View();
        }

        

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityModel collection)
        {
            try
            {
                var CountryId = TempData["CountryId"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/City");
                    var postTask = client.PostAsJsonAsync<CityModel>(client.BaseAddress, collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        _notyf.Success("Successfully Added");
                        //TempData["Message"] = "Added Successfully";
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



        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            CityModel cobj = new CityModel();
            ViewBag.EditCountryList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetCountry"));
            var Countrylist = cobj.GetAllCity().Find(c => c.Id == id);
            ViewBag.CountryId = Countrylist.CountryId;

            ViewBag.EditStateList = DatatableToClass.CommonMethod.ConvertToList<StateModel>(Utility.GetData("List_GetState"));
            var Statelist = cobj.GetAllCity().Find(c => c.Id == id);
            ViewBag.StateId = Statelist.CountryId;
            return View(cobj.GetAllCity().Find(c => c.Id == id));
           
        }



        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CityModel collection)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/City");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CityModel>(client.BaseAddress, collection);
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



        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            CityModel cobj = new CityModel();

            return View(cobj.GetAllCity().Find(c => c.Id == id));
            
        }



        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CityModel collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api");
                    var postTask = await client.DeleteAsync(client.BaseAddress + "/City/" + id);
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
               

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
