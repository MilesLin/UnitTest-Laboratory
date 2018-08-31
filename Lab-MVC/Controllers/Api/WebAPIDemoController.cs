using Lab_MVC.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;

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

        public IHttpActionResult GetOkWithNoArgument()
        {
            return Ok();
        }

        public IHttpActionResult GetBadRequest()
        {
            return BadRequest();
        }

        public IHttpActionResult GetBadRequestWithStringMessage()
        {
            return BadRequest("Error");
        }

        public IHttpActionResult GetBadRequestWithModelState()
        {
            ModelStateDictionary dic = new ModelStateDictionary();
            dic.Add("a", ModelState["abc"]);
            dic.AddModelError("err", "hello");
            return BadRequest(dic);
        }

        public IHttpActionResult GetConflict()
        {
            return Conflict();
        }

        public IHttpActionResult GetContent()
        {
            return Content(HttpStatusCode.Forbidden, 1);
        }

        public IHttpActionResult GetCreated()
        {
            return Created("http://api", new Train() { TrainId = 1 });
        }

        public IHttpActionResult GetInternalServerError()
        {
            return InternalServerError(new ArgumentNullException("參數空白"));
        }

        public IHttpActionResult GetInternalServerErrorWithNoArg()
        {
            return InternalServerError();
        }

        public IHttpActionResult GetJson()
        {
            return Json(new Train() { TrainId = 1 });
        }

        public IHttpActionResult GetNotFound()
        {
            return NotFound();
        }

        public IHttpActionResult GetRedirect()
        {
            return Redirect("http://api/home");
        }

        public IHttpActionResult GetRedirectToRoute()
        {
            return RedirectToRoute("default", new { id = 1 });
        }
    }
}