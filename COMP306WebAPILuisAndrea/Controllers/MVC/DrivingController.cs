using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using COMP306WebAPILuisAndrea.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP306WebAPILuisAndrea.Controllers.MVC
{
    [ApiController]
    public class DrivingController : Controller
    {
         readonly IMapper _mapper;

        //Constructor
        public DrivingController(IMapper mapper)
        {
            _mapper = mapper; //inject IMapper
        }
        
        //AutoMapped
        // GET: Driving
        public ActionResult Index()
        {
            IEnumerable<DrivingCentreViewModel> centres = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
                //HTTP GET
                var responseTask = client.GetAsync("drivingcentre"); //watch
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<DrivingCentre>>();
                    readTask.Wait();
                  
                    centres =  _mapper.Map<IEnumerable<DrivingCentreViewModel>>( readTask.Result); //AutoMapper usage
                }
                else //web api sent error response 
                {
                    //log response status here..

                    centres = Enumerable.Empty<DrivingCentreViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(centres);
        }

        //AutoMapper is implemented here
        // GET: Driving/5 
        public ActionResult Index(int id)
        {
            DrivingCentreViewModel centre = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
                //HTTP GET
                var responseTask = client.GetAsync("drivingcentre/" + id.ToString()); //watch
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DrivingCentre>();
                    readTask.Wait();
                    //_mapper.Map<DrivingCentreViewModel, DrivingCentre>
                    centre = _mapper.Map<DrivingCentreViewModel>( readTask.Result); //AutoMapper usage
                }
                else //web api sent error response 
                {
                    //log response status here..

                    centre = null; // Empty object

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(centre);
        }


        // GET: Driving/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driving/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(DrivingCentre centre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/drivingcentre");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<DrivingCentre>("drivingcentre", centre);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(centre);
        }


        // GET: Driving/Edit/5
        public ActionResult Update(int id)
        {
            DrivingCentre student = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
                //HTTP GET
                var responseTask = client.GetAsync("drivingcentre?addressid=" + id.ToString()); //Spelling
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DrivingCentre>();
                    readTask.Wait();

                    student = readTask.Result;
                }
            }

            return View(student);
        }

        //POST: Driving/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(DrivingCentre centre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/drivingcentre");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<DrivingCentre>("drivingcentre", centre);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(centre);
        }

        // GET: Driving/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("drivingcentre/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }

        //// POST: Driving/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
