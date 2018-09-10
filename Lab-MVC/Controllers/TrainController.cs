using Lab_MVC.Models;
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

        // GET: Train
        public ActionResult Create()
        {
            return View();
        }
    }
}