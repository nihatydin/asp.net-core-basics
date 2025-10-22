using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers
{
    public class DataPassController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // Model ile view'a veri aktarma
        public class Users 
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
        public IActionResult Model()
        {
            var users = new List<Users>
            {
                new Users { Id = 1, Name = "Ahmet" },
                new Users { Id = 2, Name = "Zeynep" }
            };
            return View(users);
        }

        // ViewBag ile view'a veri aktarma
        public IActionResult Viewbag()
        {
            ViewBag.Message = "ViewBag'den gelen mesaj";
            return View();
        }

        // ViewData ile view'a veri aktarma
        public IActionResult Viewdata()
        {
            ViewData["Message"] = "ViewData'dan gelen mesaj";
            return View();
        }

        // TempData ile view'a veri aktarma
        public IActionResult Tempdata()
        {
            return View();
        }
        public class TempdataModel
        {
            public string? Name { get; set; }
            public string? Email { get; set; }
        }
        [HttpPost]
        public IActionResult Tempdata(TempdataModel tModel)
        {
            TempData["Message"] = $"TempData ile  {tModel.Name} adlı kullanıcıdan gelen e-posta adresi: {tModel.Email}";
            return RedirectToAction("Index");
        }
        
        
    }
}