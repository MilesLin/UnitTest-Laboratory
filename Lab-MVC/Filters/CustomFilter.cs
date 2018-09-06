using Lab_MVC.Interfaces.Repositories;
using System.Web.Mvc;
using Unity.Attributes;

namespace Lab_MVC.Filters
{
    public class CustomFilter : ActionFilterAttribute, IActionFilter
    {
        [Dependency]
        public ITrainRepository TrainRepository { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var a = TrainRepository.TheNameIsExist("123");
            base.OnActionExecuting(filterContext);
        }
    }
}