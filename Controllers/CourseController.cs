using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_basics.Controllers;

public class CourseController : Controller
{
        List<Course> kurslar = new List<Course>
        {
           new Course {
                Id= 1,
                Title = "Js Course",
                Image = "image.png",
                Description = "Js is a programming language for frontend development.",
                Price = 80000,
                IsActive = true
           },
            new Course{
                Id= 2,
                Title = "React Course",
                Image = "image.png",
                Description = "React is a library for js in frontend.",
                Price = 90000,
                IsActive = true
            },
            new Course{
                Id= 3,
                Title = "C# Course",
                Image = "image.png",
                Description = "C# is a programming language.",
                Price = 110000,
                IsActive = true
            },
            new Course{
                Id= 4,
                Title = "Java Course",
                Image = "image.png",
                Description = "Java is a programming language.",
                Price = 100000,
                IsActive = false
            }

        };
    public ActionResult Index()
    {


        return View(kurslar);
    }

    public ActionResult Details(int id)
    {

        Course? kurs = kurslar.Where(x=>x.Id == id).FirstOrDefault();

        return View(kurs);
    }

    public ActionResult List()
    {

        // string example = "model yapısı örnek kullanım => eğer string tipinde bir model gönderilecekse  View() içerisindeki viewname de string olacağından viewname girmeliyiz. Ancak string tipinden farklı bir model tanımlanmışsa viewname yazmaya gerek yokur.";
        //  int example2 = 34;

        //  string[] urunDizisi = ["React bir js frameworkudur.", "asp.net core web uygulamaları geliştirmek için kullanıılır."];


        //-------------------------------------------------------
        // buradaki 3 farklı kurs tanımlaması da aynı sonuca yarar.
     /*
        Course kurs1 = new Course();
        kurs1.Title = "React Kursu";
        kurs1.Image = "image.png";
        kurs1.Description = "React is a Js framework.";
        kurs1.Price = 70000;

        Course kurs2 = new Course
        {
            Title = "React Kursu",
            Image = "image.png",
            Description = "Asp.net is a fullstack web framework.",
            Price = 90000,
        };

        Course kurs3 = new()
        {
            Title = "C# Kursu",
            Image = "image.png",
            Description = "C# is a programming language.",
            Price = 100000,
        };
      */

        //Course[] kurslar = [kurs1, kurs2];
      /*  List<Course> kurslar = new List<Course>
        {
            // kurs1, kurs2,kurs3
           new Course {
                Title = "Js Kursu",
                Image = "image.png",
                Description = "Js is a programming language for frontend development.",
                Price = 80000,
                IsActive = true
           },
            new Course{
                Title = "React Kursu",
                Image = "image.png",
                Description = "Asp.net is a fullstack web framework.",
                Price = 90000,
                IsActive = true
            },
            new Course{
                Title = "C# Kursu",
                Image = "image.png",
                Description = "C# is a programming language.",
                Price = 110000,
                IsActive = false
            }

        };*/
        return View(kurslar);
    }   

}
