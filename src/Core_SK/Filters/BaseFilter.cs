using System.Linq;
using System.Text.RegularExpressions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

namespace CoreSK.Filters
{
    /// <summary>
    /// BasePath Document Filter sets BasePath property of Swagger and removes it from the individual URL paths
    /// </summary>
    public class BaseFilter : IDocumentFilter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseURL">BasePath to remove from Operations</param>
        public BaseFilter(string baseURL, string basePath, string serverDescription)
        {
            BaseURL = baseURL;
            BasePath = basePath;
            ServerDescription = serverDescription;
        }

        /// <summary>
        /// Gets the BasePath of the Swagger Doc
        /// </summary>
        /// <returns>The BasePath of the Swagger Doc</returns>
        public string BaseURL { get; }
        public string BasePath { get; }
        public string ServerDescription { get; }

        /// <summary>
        /// Apply the filter
        /// </summary>
        /// <param name="swaggerDoc">OpenApiDocument</param>
        /// <param name="context">FilterContext</param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {

            if (!swaggerDoc.Info.Extensions.ContainsKey("x-summary"))
            {
                swaggerDoc.Info.Extensions.Add("x-summary", new OpenApiString(swaggerDoc.Info.Description));
            }

            swaggerDoc.Servers.Add(new OpenApiServer() { Url = this.BaseURL +this.BasePath });
            
            var servers = swaggerDoc.Servers;

            foreach (OpenApiServer server in servers)
            {
              //  server.Url=  BaseURL + server.Url;
                server.Description = ServerDescription;
            }


        }
    }
}
