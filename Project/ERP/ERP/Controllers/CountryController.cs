using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using Nancy.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace ERP.Controllers
{
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly INotyfService _notyf;

        public CountryController(ILogger<CountryController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notyf = notyf;
        }

        // GET: CountryController
        public ActionResult Index()
        {
            //CountryModel repo = new CountryModel();
            //ModelState.Clear();
            //var a =  repo.List();
            //List<CountryModel> List = getdata();
            //ViewBag.List = List;
           
                    return View();
            
            
            
        }

        [HttpGet]
        public ActionResult getdata()
        {
            string baseurl = "http://192.168.10.34:81/api/" + "Country";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resstream = response.GetResponseStream();
            var value = new StreamReader(resstream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<CountryModel>>(value);
            //return data;
            return View("Index",data);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            
            return View();
        }

    
        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(CountryModel collection)
        {
            
            try
            {
               

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api/Country");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CountryModel>(client.BaseAddress ,collection);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        _notyf.Custom("Successfully Added",5,"Green","fa fa-check");
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

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            CountryModel cobj = new CountryModel();
            
            return View(cobj.GetAllCountries().Find(c => c.Id == id));

        }

        

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CountryModel collection)
        {
            //try
            //{
            //    collection.Insert(collection);
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            try 
            { 

                 using (var client = new HttpClient())
                 {
                     client.BaseAddress = new Uri("http://192.168.10.34:81/api/Country");

                     //HTTP POST
                     var postTask = client.PostAsJsonAsync<CountryModel>(client.BaseAddress, collection);
                     postTask.Wait();

                     var result = postTask.Result;
                     if (result.IsSuccessStatusCode)
                     {
                        _notyf.Custom("Edited Successfully", 5, "#89CFF0", "fa fa-pencil");
                        //TempData["Message"] = "Successfully Edited";
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

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id,string a)
        {
            CountryModel cobj = new CountryModel();

            return View(cobj.GetAllCountries().Find(c => c.Id == id));
            
        }
        //public class DeleteCountry
        //{
        //    public bool isSuccess { get; set; }
        //}
        // POST: CountryController/Delete/5
         [HttpPost]
        
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>   Delete( int id)
        {           
            try
            { 
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://192.168.10.34:81/api");
                    var   postTask = await client.DeleteAsync(client.BaseAddress + "/Country/" + id);
                    var jsonString = postTask.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer deSerializedResponse = new JavaScriptSerializer();
                    var data = deSerializedResponse.Deserialize<DeleteStatus>(jsonString);
                    if (data.isSuccess)
                    {
                        _notyf.Custom("Deleted Successfully", 5, "Green", "fa fa-trash");
                        RedirectToAction("Index");
                    }
                    else if(!data.isSuccess)
                    {
                        _notyf.Custom("This Country is in use", 5, "#FA5F55", "fa fa-exclamation-circle");
                        return RedirectToAction("Index");
                    }
                    
                    //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
               
                return RedirectToAction("Index"); ;
            }
        }

        [HttpGet]
        public ActionResult Block(int id, CountryModel collection)
        {
            try
            {
                collection.BlockCountry(collection);
                var a = collection.BlockCountryget(collection);
                if (a ==true)
                {
                    ViewBag.yes = a;
                    ViewBag.Message = "Blocked";
                    TempData["status"] = "Blocked";
                }
                else
                {
                    ViewBag.Message = "UnBlocked";
                    TempData["status"] = "UnBlocked";
                }

                string b = string.Empty;
                

                return RedirectToAction("Index");
                
            }
            catch (Exception ex )
            {
                return RedirectToAction("Index");
            }
        }



    }
}
