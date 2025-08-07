using Microsoft.AspNetCore.Mvc.Filters;

namespace Student_Managmet_MVC.Filter
{
    public class LoggingFliter: ActionFilterAttribute
    {
        //After action
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action Method {context.ActionDescriptor.DisplayName} is executing at {DateTime.Now}");
            base.OnActionExecuting(context);
        }
        //Before action
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Method {context.ActionDescriptor.DisplayName} has executed at {DateTime.Now}");
            base.OnActionExecuted(context);
        }
    }
}
