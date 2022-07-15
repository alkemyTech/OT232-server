using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Middleware
{
    public class UserAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public UserAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool containsPath = false;
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();
            var role = context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Role);

            List<string> methods = new()
            {
                "PATCH",
                "PUT",
                "POST",
                "DELETE"
            };

            List<string> paths = new()
            {
                "/api/Activities",
                "/api/Categories",
                "/api/Comments",
                "/api/News",
                "/api/Contacts",
                "/api/Members",
                "/api/Organizations",
                "/api/Roles",
                "/api/Slides",
                "/api/Testimonials"
            };

            foreach (string p in paths)
                if (path.StartsWith(p))
                    containsPath = true;

            if (methods.Contains(method) && containsPath)
            {
                if (!role.Value.Equals("Administrador"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
