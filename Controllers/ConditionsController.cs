using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return await ProxyCall("AllergyIntolerance", access_token, patient);

        }
        
        [HttpGet("conditions")]
        public async Task<ContentResult> GetConditions([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("Condition", access_token, patient);
        }

        [HttpGet("diagnostic")]
        public async Task<ContentResult> GetDiagnostic([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("DiagnosticReport", access_token, patient);
        }

        [HttpGet("immunization")]
        public async Task<ContentResult> GetImmunization([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("Immunization", access_token, patient);
        }

        [HttpGet("medications")]
        public async Task<ContentResult> GetMeds([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("MedicationOrder", access_token, patient);
        }
        [HttpGet("medstatements")]
        public async Task<ContentResult> GetMedStatements([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("MedicationStatement", access_token, patient);
        }
           [HttpGet("observation")]
        public async Task<ContentResult> GetObservations([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("Observation", access_token, patient);
        }

             [HttpGet("procedure")]
        public async Task<ContentResult> GetProcedure([FromQuery] string access_token, [FromQuery] string patient)
        {
            return await ProxyCall("Procedure", access_token, patient);
        }
    
        private async Task<ContentResult> ProxyCall(string endpoint, string access_token, string patient){
            string url = $"https://sandbox-api.va.gov/services/fhir/v0/argonaut/data-query/{endpoint}?patient={patient}&_count=100";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);


            var resp = await client.GetAsync(url);
            var body = await resp.Content.ReadAsStringAsync();


            return new ContentResult{Content = body, ContentType = "application/json"};
        }

    }
}