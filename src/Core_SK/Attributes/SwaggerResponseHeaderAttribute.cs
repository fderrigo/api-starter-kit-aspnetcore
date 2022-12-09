using System;

namespace Core_SK.Attributes
{
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SwaggerResponseHeaderAttribute : Attribute
    {
        public SwaggerResponseHeaderAttribute(int statusCode, string name, string type, string description, string url, string format = "")
        {
            StatusCodes = new int[] { statusCode };
            Name = name;
            Type = type;
            Description = description;
            Format = format;
            Url = url;
        }

        public SwaggerResponseHeaderAttribute(int[] statusCode, string name, string type, string description, string url, string format = "")
        {
            StatusCodes = statusCode;
            Name = name;
            Type = type;
            Description = description;
            Format = format;
            Url = url;
        }

        public int[] StatusCodes { get; }

        public string Name { get; }

        public string Type { get; }

        public string Description { get; }

        public string Format { get; }
        public string Url { get; }
    }
}