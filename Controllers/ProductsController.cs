using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using dotnet_basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products = new()

        {
           new Product {
                Id= 1,
                Title = "Iphone 12",
                Image = "image.png",
                Description = "Good phone",
                Price = 80000,
                IsActive = true,
                IsHome=true
           },
            new Product{
                Id= 2,
                Title = "Iphone 13",
                Image = "image.png",
                Description = "Great phone",
                Price = 90000,
                IsActive = true,
                IsHome=true
            },
            new Product{
                Id= 3,
                Title = "Iphone 14",
                Image = "image.png",
                Description = "Fantastic phone",
                Price = 110000,
                IsActive = true,
                IsHome=true
            },
            new Product{
                Id= 4,
                Title = "Iphone 15",
                Image = "image.png",
                Description = "Really good phone",
                Price = 100000,
                IsActive = false,
                IsHome=false
            },
              new Product{
                Id= 4,
                Title = "Iphone 16",
                Image = "image.png",
                Description = "Excellent phone",
                Price = 160000,
                IsActive = false,
                IsHome=false
            }

        };

        
        public ActionResult Index()
        {
            
           List<Product> filteredProducts = products.Where(p => p.IsHome).ToList();

            return View(filteredProducts);
        }

        public ActionResult Details(int id)
        {
            Product? product = products.Where(x=>x.Id == id).FirstOrDefault();

            return View(product);
        }
        public ActionResult List()
        {


            return View(products);
        }

    }
}