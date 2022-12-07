using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.MobileEndpoint.Controllers.BaseControllers
{
    public class IgnoreApiAttribute : ActionFilterAttribute, IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription description in context.ApiDescriptions)
            {

                description.TryGetMethodInfo(out MethodInfo info);

                var devAttributes = info.GetCustomAttributes(true).OfType<IgnoreApiAttribute>().Distinct();


                if (devAttributes.Any())
                {
                    string kepath = description.RelativePath;

                    var removeRoutes = swaggerDoc.Paths.Where(
                        p => p.Key.ToLower().Contains(kepath.ToLower()))
                        .ToList();

                    removeRoutes.ForEach(x => { swaggerDoc.Paths.Remove(x.Key); });
                }
                                    

            }
        }
    }
}
