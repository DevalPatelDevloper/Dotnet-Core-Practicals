using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using practical17MVC.Helper;
using practical17MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace practical17MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        StudentAPI studentAPI = new StudentAPI();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Student1> student1s = new List<Student1>();
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Students");
            if(res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                student1s = JsonConvert.DeserializeObject<List<Student1>>(results);
            }
            return View(student1s);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var student = new Student1();
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Students/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                student= JsonConvert.DeserializeObject<Student1>(results);
            }
            return View(student);

        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(Student1 student1)
        {
            HttpClient client = studentAPI.Initial();
            //HTTP POST
            var res =client.PostAsJsonAsync<Student1>("api/Students",student1);
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var student = new Student1();
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Students/{Id}");
            return RedirectToAction("Index");

        }
        
        public async Task<IActionResult> Edit(int Id)
        {
            var student = new Student1();
            HttpClient client = studentAPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Students/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<Student1>(results);
            }
            return View(student);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id,Student1 student)
        {


            HttpClient client = studentAPI.Initial();
            //HTTP POST
            var res = client.PutAsJsonAsync<Student1>($"api/Students/{Id}", student);
            res.Wait();
            var result = res.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
