using Lab_MVC.Filters;
using Lab_MVC.Interfaces.Repositories;
using Lab_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace Lab_MVC.Controllers
{        
    public class HomeController : Controller
    {
        IPaymentTransactionRepository _repo;
        IPaymentTransactionRepository _repo2;
        public HomeController(IPaymentTransactionRepository repo,
            IPaymentTransactionRepository repo2)
        {
            _repo = repo;
            _repo2 = repo2;
        }

        [CustomFilter]
        public ActionResult Index(Train train)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}