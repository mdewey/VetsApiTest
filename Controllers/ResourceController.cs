using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VetsApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
           
        private static readonly HttpClient client = new HttpClient();


        [HttpGet("{resource}")]
        public async Task<ActionResult> GetAllergies([FromRoute] string resource, [FromQuery] string access_token, [FromQuery] string resourceId)
        {
            return await ProxyCall(resource, access_token, resourceId);
        }

         private async Task<ContentResult> ProxyCall(string endpoint, string access_token, string resourceId){
            string url = $"https://sandbox-api.va.gov/services/fhir/v0/dstu2/{endpoint}/{resourceId}";
            Console.WriteLine(url);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);


            var resp = await client.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();


            return new ContentResult{Content = body, ContentType = "application/json"};
        }


    }
}