using Lab_MVC.Interfaces.Services;
using Lab_MVC.Models;
using Lab_MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab_MVC.Controllers
{
    public class MVCDemoController : Controller
    {
        private List<Train> _trains;
        private IInvoiceService _invoiceService;
        


        public MVCDemoController(
            IInvoiceService invoiceService
            )
        {
            _invoiceService = invoiceService;

            _trains = new List<Train>()
            {
                new Train { TrainId = 1, TrainName = "XY-3443", Destination = "Torrance", DepartureTime = new DateTime(2018,10,1) },
                new Train { TrainId = 2, TrainName = "UY-0001", Destination = "Venice", DepartureTime = new DateTime(2018,10,5) },
                new Train { TrainId = 3, TrainName = "ZX-9431", Destination = "Santa", DepartureTime = new DateTime(2018,10,7) }
            };
        }

        [HttpPost]
        public ActionResult CreateInvoice(Invoice invoice)
        {
            var result = this._invoiceService.CreateInvoice(invoice);

            return Json(result);
        }

        public ActionResult GetView(int trainId)
        {
            var result = _trains.First(x => x.TrainId == trainId);

            return View(result);
        }

        public ActionResult GetPartialView(int trainId)
        {
            var result = _trains.First(x => x.TrainId == trainId);

            return PartialView(result);
        }

        public ActionResult GetContent()
        {
            return Content("Hello", "text/csv");
        }

        public ActionResult GetFile()
        {
            return File(new byte[] { }, "text/csv", "abc.xls");
        }

        public ActionResult GetJson()
        {
            return Json(new { Name = "Miles" });
        }

        public ActionResult GetJavaScript()
        {
            return JavaScript("alert('hi')");
        }

        public ActionResult GetRedirect()
        {
            return Redirect("http://google.com");
            //return RedirectPermanent("http://google.com");
        }

        public ActionResult GetRedirectToRoute()
        {
            return RedirectToRoute(new { action = "Index", controller = "Home" });
            //return RedirectToRoutePermanent(new { action = "Index", controller = "Home" });
        }

        public ActionResult GetRedirectToAction()
        {
            return RedirectToAction("Index", "Home", new { id = 10 });
            //return RedirectToActionPermanent("Index", "Home", new { id = 10 });
        }

        public ActionResult GetHttpNotFound()
        {
            return HttpNotFound("Not Found");
        }
    }
}