using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Form üzerinden parametre ile kullanıcıdan veri alma
        /* [HttpPost]
          public IActionResult Index(string name, string email)
         {
             ViewBag.Message = $"Thank you {name}, we will contact you shortly at {email}.";
             return View();
         }*/


        //Form üzerinden IFormCollection ile kullanıcıdan veri alma 
        /* [HttpPost]
         public IActionResult Index(IFormCollection form)
         {
             var name = form["Name"];
             var email = form["Email"];
             ViewBag.Message = $"Thank you {name}, we will contact you shortly at {email}.";
             return View();
         }*/

        //Form üzerinden Model ile kullanıcıdan veri alma
        [HttpPost]
        public IActionResult Index(Contact model)
        {
            ViewBag.Message = $"Thank you {model.Name}, we will contact you shortly at {model.Email}.";
            return View();
        }


        //Query String ile kullanıcıdan veri alma (3 farklı şekilde)
        //Request.Query ile
        /*  public IActionResult GetData()
          {
              var queryString = Request.QueryString; // Request yapılan endpointe query string parametresi eklenmiş eklenmemiş mi hakkında bilgi verir.
              var a = Request.Query["category"].ToString(); // Query string parametrelerine erişim sağlar.
              var b = Request.Query["brand"].ToString();
              Console.WriteLine(a + b);

              return View();
          }*/

        // Parametre ile
        /*public IActionResult GetData(string category, string brand)
        {
            //Contact/GetData?category=phones&brand=apple
            ViewBag.Message = $"Category: {category}, Brand: {brand}";
            return View();
        }*/

        // Model ile
        /*  public class QueryModel
          {
              public string? Category { get; set; }
              public string? Brand { get; set; }
          }
          public IActionResult GetData(QueryModel qmodel)
          {
              //Contact/GetData?category=phones&brand=apple
              return View(qmodel);
          }*/


        // Route Parameter ile kullanıcıdan veri alma
        // Parametre ile
       /* public IActionResult GetData(string name, string surname, int age)
        {
            // Contact/GetData/Nihat/Aydin/23
            ViewBag.Message = $"Name: {name}, Surname: {surname}, Age: {age}";
            return View();
        }*/
        
        // Model ile
        public class RouteModel
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public int Age { get; set; }
        }
        public IActionResult GetData(RouteModel rmodel)
        {
            // Contact/GetData/Nihat/Aydin/23
            return View(rmodel);
        }
        
    }
}