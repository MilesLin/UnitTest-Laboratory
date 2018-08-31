﻿using Lab_MVC.Models;
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
    }
}