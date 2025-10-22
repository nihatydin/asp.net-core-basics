using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers
{
    public class UserInputController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Form üzerinden parametre ile kullanıcıdan veri alma
        /* [HttpPost]
          public IActionResult Form(string name, string email)
         {
             ViewBag.Message = $"Thank you {name}, we will contact you shortly at {email}.";
             return View();
         }*/


        //Form üzerinden IFormCollection ile kullanıcıdan veri alma 
        /* [HttpPost]
         public IActionResult Form(IFormCollection form)
         {
             var name = form["Name"];
             var email = form["Email"];
             ViewBag.Message = $"Thank you {name}, we will contact you shortly at {email}.";
             return View();
         }*/

        //Form üzerinden Model ile kullanıcıdan veri alma
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form(UserInput uModel)
        {
            ViewBag.Message = $"Thank you {uModel.Name}, we will contact you shortly at {uModel.Email}.";
            return View();
        }


        //Query String ile kullanıcıdan veri alma (3 farklı şekilde)
        //Request.Query ile
        /*  public IActionResult QueryString()
          {
              var queryString = Request.QueryString; // Request yapılan endpointe query string parametresi eklenmiş eklenmemiş mi hakkında bilgi verir.
              var a = Request.Query["category"].ToString(); // Query string parametrelerine erişim sağlar.
              var b = Request.Query["brand"].ToString();
              Console.WriteLine(a + b);

              return View();
          }*/

        // Parametre ile
        /*public IActionResult QueryString(string category, string brand)
        {
            //UserInput/QueryString?category=phones&brand=apple
            ViewBag.Message = $"Category: {category}, Brand: {brand}";
            return View();
        }*/

        // Model ile
          public class QueryModel
          {
              public string? Category { get; set; }
              public string? Brand { get; set; }
          }
          public IActionResult QueryString(QueryModel qmodel)
          {
              //UserInput/QueryString?category=phones&brand=apple
              return View(qmodel);
          }


        // Route Parameter ile kullanıcıdan veri alma
        // Parametre ile
       /* public IActionResult RouteParameter(string name, string surname, int age)
        {
            // UserInput/RouteParameter/Nihat/Aydin/23
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
        public IActionResult RouteParameter(RouteModel rmodel)
        {
            // UserInput/RouteParameter/Nihat/Aydin/23
            return View(rmodel);
        }

        // Header Bilgilerine Erişim
        public IActionResult Header()
        {
            // var header = Request.Headers.ToList(); // Tüm header bilgilerini alır.
            var value = Request.Headers["lorem"]; // Belirli bir header bilgisine erişim sağlar.
            Console.WriteLine(value);
            
            return View();
        }

        // Ajax ile Veri Alışverişi
        public class AjaxModel
        {
            public string? Name { get; set; }
            public int Age { get; set; }
        }

        public IActionResult Ajax()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajax([FromBody] AjaxModel ajaxModel)
        {
            return Json(new { message = $"Veri alındı: {ajaxModel.Name}, {ajaxModel.Age}" });
        }

        
    }
}