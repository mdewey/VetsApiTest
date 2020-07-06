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


        [HttpGet("allergies")]
        public async Task<ActionResult> GetAllergies([FromQuery] string access_token, [FromQuery] string resourceId)
        {
            return await ProxyCall("AllergyIntolerance", access_token, resourceId);

        }

         private async Task<ContentResult> ProxyCall(string endpoint, string access_token, string resourceId){
            string url = $"https://sandbox-api.va.gov/services/fhir/v0/dstu2/{endpoint}/{resourceId}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);


            var resp = await client.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();


            return new ContentResult{Content = body, ContentType = "application/json"};
        }


    }
}