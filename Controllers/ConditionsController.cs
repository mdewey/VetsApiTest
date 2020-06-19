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
    public class ConditionsController : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        [HttpGet("allergies")]
        public async Task<ActionResult> GetAllergies([FromQuery] string access_token, [FromQuery] string patient)
        {
            string url = $"https://sandbox-api.va.gov/services/fhir/v0/argonaut/data-query/AllergyIntolerance?patient=${patient}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);


            var resp = await client.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();

            return Ok(new { access_token, patient, body });
        }
    }
}