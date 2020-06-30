using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VetsApiTest.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpGet("login")]
        public async Task<ActionResult> DoFirstAuth()
        {
            var url = $@"https://sandbox-api.va.gov/oauth2/authorization?client_id=0oa7iad5rpW3R4iNY2p7&redirect_uri=https://localhost:5001/callback&response_type=code&scope=openid offline_access profile email veteran_status.read launch/patient patient/Procedure.read patient/Observation.read patient/MedicationStatement.read patient/MedicationOrder.read patient/Medication.read patient/Immunization.read patient/DiagnosticReport.read patient/CommunityCareEligibility.read patient/CoverageEligibilityResponse.read patient/Condition.read patient/Patient.read patient/AllergyIntolerance.read&state={DateTime.Now.Millisecond}&nonce={DateTime.Now.Millisecond + 5}";
            return Redirect(url);
        }
    }
}