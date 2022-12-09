/*
 * Ora esatta.
 *
 * #### Documentazione Il servizio Ora esatta ritorna l'ora del server in formato RFC5424 (syslog).  `2018-12-30T12:23:32Z`  ##### Sottosezioni E' possibile utilizzare - con criterio - delle sottosezioni.  #### Note  Il servizio non richiede autenticazione, ma va' usato rispettando gli header di throttling esposti in conformita' alle Linee Guida del Modello di interoperabilita'.  #### Informazioni tecniche ed esempi  Esempio:  ``` http http://localhost:8443/datetime/v1/echo {   'datetime': '2018-12-30T12:23:32Z' } ``` 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: filippo.derrigo@gmail.com
 */

using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CoreSK.Attributes;

using CoreSK.Models;
using Core_SK.Filters;
using System.Net.Mime;
using Microsoft.OpenApi.Models;
using Core_SK.Attributes;

namespace CoreSK.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// Ritorna un timestamp in formato RFC5424.
        /// </summary>
        /// <remarks>Ritorna un timestamp in formato RFC5424 prendendola dal server attuale. </remarks>
        /// <response code="200">Il server ha ritornato il timestamp. </response>
        [HttpGet]
        [Route("/datetime/v1/echo")]
        [ValidateModelState]
        [SwaggerOperation("GetEcho")]
        [SwaggerResponse(statusCode: 200, type: typeof(Timestamps), description: "Il server ha ritornato il timestamp. ")]
        [SwaggerResponseMimeType(400, typeof(Problem), "application/problem+json", Description = "Bad Request")]
        [SwaggerResponseMimeType(429, typeof(Problem), "application/problem+json", Description = "Bad Request")]
        [SwaggerResponseMimeType(503, typeof(Problem), "application/problem+json", Description = "Too Many Requests")]
        [SwaggerResponseHeader(200, "X-RateLimit-Limit", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Limit", "")]
        [SwaggerResponseHeader(200, "X-RateLimit-Remaining", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Remaining", "")]
        [SwaggerResponseHeader(200, "X-RateLimit-Reset", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Reset", "")]

        [SwaggerResponseHeader(429, "Retry-After", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/Retry-After", "")]
        [SwaggerResponseHeader(429, "X-RateLimit-Limit", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Limit", "")]
        [SwaggerResponseHeader(429, "X-RateLimit-Remaining", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Remaining", "")]
        [SwaggerResponseHeader(429, "X-RateLimit-Reset", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Reset", "")]

        [SwaggerResponseHeader(503, "Retry-After", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/Retry-After", "")]
        public virtual IActionResult GetEcho()
        {

            Random rnd = new Random();
            int num = rnd.Next(0, 10);
            Problem problem;
            if (num < 7)
            {
            Timestamps ts = new Timestamps();
            ts.Timestamp = DateTime.UtcNow;
            Response.Headers.Add("X-RateLimit-Limit", "1");
            Response.Headers.Add("X-RateLimit-Remaining", "1");
            Response.Headers.Add("X-RateLimit-Reset", "1");
            return new ObjectResult(ts);
            }
            else if (num < 9)
            {
                problem = new Problem
                {
                    Status = 503,
                    Title = "Service Unavailable",
                    Detail = "Questo errore viene ritornato randomicamente."
                };
                Response.Headers.Add("Retry-After", "1");
                return new ObjectResult(problem);
            }
            problem = new Problem
            {
                Status = 429,
                Title = "Too Many Requests",
                Detail = "Questo errore viene ritornato randomicamente."

            };
            Response.Headers.Add("Retry-After", "1");
            Response.Headers.Add("X-RateLimit-Limit", "1");
            Response.Headers.Add("X-RateLimit-Remaining", "1");
            Response.Headers.Add("X-RateLimit-Reset", "1");
            return new ObjectResult(problem);


        }

        /// <summary>
        /// Ritorna lo stato dell'applicazione.
        /// </summary>
        /// <remarks>Ritorna lo stato dell'applicazione. A scopo di test, su base randomica puo' ritornare un errore. </remarks>
        /// <response code="200">Il server ha ritornato lo status. In caso di problemi ritorna sempre un problem+json. </response>
        [HttpGet]
        [Route("/datetime/v1/status")]
        [ValidateModelState]
        [SwaggerOperation("GetStatus")]
        //[SwaggerResponse(statusCode: 200, description: "Il server ha ritornato lo status. In caso di problemi ritorna sempre un problem+json. ", type: typeof(Problem))]
        [SwaggerResponseMimeType(200, typeof(Problem), "application/problem+json", Description = "Il server ha ritornato lo status. In caso di problemi ritorna sempre un problem+json.")]
        [SwaggerResponseMimeType(400, typeof(Problem), "application/problem+json", Description = "Bad Request")]
        [SwaggerResponseMimeType(429, typeof(Problem), "application/problem+json", Description = "Bad Request")]
        [SwaggerResponseMimeType(503, typeof(Problem), "application/problem+json", Description = "Too Many Requests")]

        [SwaggerResponseHeader(200, "X-RateLimit-Limit", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Limit", "")]
        [SwaggerResponseHeader(200, "X-RateLimit-Remaining", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Remaining", "")]
        [SwaggerResponseHeader(200, "X-RateLimit-Reset", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Reset", "")]

        [SwaggerResponseHeader(429, "Retry-After", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/Retry-After", "")]
        [SwaggerResponseHeader(429, "X-RateLimit-Limit", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Limit", "")]
        [SwaggerResponseHeader(429, "X-RateLimit-Remaining", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Remaining", "")]
        [SwaggerResponseHeader(429, "X-RateLimit-Reset", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/X-RateLimit-Reset", "")]

        [SwaggerResponseHeader(503, "Retry-After", "", "", "https://teamdigitale.github.io/openapi/0.0.7/definitions.yaml#/headers/Retry-After", "")]
        public virtual IActionResult GetStatus()
        {

            Response.Headers.Add("Cache-Control", "no-store");

            Random rnd = new Random();
            int num = rnd.Next(0, 10);
            Problem problem;
            if (num < 7)
            {
                problem = new Problem
                {
                    Status = 200,
                    Title = "Success",
                    Detail = "Il servizio funziona correttamente"
                };
                Response.Headers.Add("X-RateLimit-Limit", "1");
                Response.Headers.Add("X-RateLimit-Remaining", "1");
                Response.Headers.Add("X-RateLimit-Reset", "1");
                return new ObjectResult(problem);
            }
            else if (num < 9)
            {
                problem = new Problem
                {
                    Status = 503,
                    Title = "Service Unavailable",
                    Detail = "Questo errore viene ritornato randomicamente."
                };
                Response.Headers.Add("Retry-After", "1");
                return new ObjectResult(problem);
            }
            problem = new Problem
            {
                Status = 429,
                Title = "Too Many Requests",
                Detail = "Questo errore viene ritornato randomicamente."

            };
            Response.Headers.Add("Retry-After", "1");
            Response.Headers.Add("X-RateLimit-Limit", "1");
            Response.Headers.Add("X-RateLimit-Remaining", "1");
            Response.Headers.Add("X-RateLimit-Reset", "1");
            return new ObjectResult(problem);
        }
    }
}
