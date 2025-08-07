namespace Student_Managmet_MVC.Middleware
{
    public class RequestLogsURLMaddleware
    {

        private readonly RequestDelegate _next;
        public RequestLogsURLMaddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            Console.WriteLine($"Request URL: {context.Request.Path}");
            
            await _next(context);
          
        }
    }
}
