using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;

namespace Presentation
{
    public class CacheAttribute(int DurationBySeconds = 90) : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // 1️⃣ Create Cache Key
            ICasheService casheService = context.HttpContext.RequestServices.GetRequiredService<ICasheService>();
            string cacheKey = CreateCacheKey(context.HttpContext.Request);

            // 2️⃣ Search For Value In Cache
            var cacheValue = await casheService.GetAsync(cacheKey);

            if (cacheValue is not null)
            {
                context.Result = new ContentResult()
                {
                    Content = cacheValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }

            // 3️⃣ Execute Action
            var executedContext = await next();

            // 4️⃣ Set Cache
            if (executedContext.Result is ObjectResult result)
            {
                await casheService.SetAsync(cacheKey, result.Value!, TimeSpan.FromSeconds(DurationBySeconds));
            }
        }

        private static string CreateCacheKey(HttpRequest request)
        {
            var key = new StringBuilder();
            key.Append(request.Path);

            if (request.Query.Any())
            {
                key.Append('?');
                foreach (var item in request.Query.OrderBy(q => q.Key))
                {
                    key.Append($"{item.Key}={item.Value}&");
                }
            }

            return key.ToString().TrimEnd('&');
        }
    }
}
  