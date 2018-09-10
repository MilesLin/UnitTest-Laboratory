using Lab_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lab_MVC.Controllers
{
    public class TrainController : Controller
    {
        private WebPayment _db;

        public TrainController(WebPayment db)
        {
            _db = db;
        }

        // GET: Train
        public ActionResult Index(string trainName)
        {
            var trains = _db.Train.AsQueryable();

            if (!string.IsNullOrEmpty(trainName))
            {
                trains = trains.Where(x => x.TrainName.Contains(trainName));
            }

            return View(trains.ToList());
        }

        [HttpPost]
        public ActionResult Create(Train train)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> listItem = new List<SelectListItem>()
                {
                    new SelectListItem { Text = "進入廠區", Value = "1" },
                    new SelectListItem { Text = "離開廠區", Value = "0" }
                };

                ViewBag.TrainTypeList = new SelectList(listItem, "Value", "Text");

                return View(train);
            }

            _db.Train.Add(train);
            _db.SaveChanges();

            TempData["Inserted"] = $"{train.TrainName} 資料新增成功";

            return RedirectToAction("Index");
        }
    }
}