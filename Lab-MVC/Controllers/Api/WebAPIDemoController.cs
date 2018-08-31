using Lab_MVC.Models;
using System.Web.Http;

namespace Lab_MVC.Controllers.Api
{
    public class WebAPIDemoController : ApiController
    {
        public IHttpActionResult GetOk()
        {
            var train = new Train()
            {
                TrainId = 1
            };
            return Ok(train);
        }

        public IHttpActionResult GetOkWithAnonymous()
        {
            var obj = new
            {
                Id = 1,
                Name = "Miles"
            };

            return Ok(obj);
        }
    }
}