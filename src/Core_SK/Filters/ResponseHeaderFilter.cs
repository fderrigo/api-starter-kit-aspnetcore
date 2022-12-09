using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Core_SK.Attributes;

namespace Core_SK.Filters
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    public class SwaggerResponseHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionAttributes = context.MethodInfo
            .GetCustomAttributes(true)
            .OfType<SwaggerResponseHeaderAttribute>()
            .ToList();

            foreach (var attr in actionAttributes)
            {
                foreach (var statusCode in attr.StatusCodes)
                {
                    var response = operation.Responses.FirstOrDefault(x => x.Key == (statusCode).ToString(CultureInfo.InvariantCulture)).Value;

                    if (response != null)
                    {
                        if (response.Headers == null)
                        {
                            response.Headers = new Dictionary<string, OpenApiHeader>();
                        }

                        response.Headers.Add(attr.Name, new OpenApiHeader
                        {
                            Description = attr.Description,
                            Reference = new OpenApiReference { ExternalResource = attr.Url }
                            //Reference = new OpenApiReference {  Type= ReferenceType., Id = attr. }
                            //TO DO
                            //Type = xxx;
                            //Format = xx;

                        });
                    }
                }
            }
        }
    }
}