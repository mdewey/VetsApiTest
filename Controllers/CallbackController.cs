using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace VetsApiTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private HttpClient client = new HttpClient();

        public partial class AuthedResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("id_token")]
            public string IdToken { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("scope")]
            public string Scope { get; set; }

            [JsonProperty("expires_in")]
            public long ExpiresIn { get; set; }

            [JsonProperty("patient")]
            public string Patient { get; set; }

            [JsonProperty("state")]
            public long State { get; set; }
        }

        readonly private string ClientId;
        readonly private string Secret;

        public CallbackController(IConfiguration config)
        {
            this.ClientId = config["CLIENT_ID"];
            this.Secret = config["SECRET"];
        }

        [HttpGet]
        public async Task<ActionResult> Index(string id_token, string code, string state)
        {
            var clientId = this.ClientId;
            var secret = this.Secret;


            // do a post. 
            var url = "https://sandbox-api.va.gov/oauth2/token";

            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Host", "sandbox-api.va.gov");

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{clientId}:{secret}");
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {System.Convert.ToBase64String(plainTextBytes)}");


            var parameters = new Dictionary<string, string> {
                { "grant_type", "authorization_code" },
                { "code", code },
                {"state" , state},
                {"redirect_uri" , "https://localhost:5001/callback"}
    };
            var encodedContent = new FormUrlEncodedContent(parameters);

            var response = await client.PostAsync(url, encodedContent);

            var body = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<AuthedResponse>(body);
            var successUrl = $@"/success?access_token={resp.AccessToken}&id_token={resp.IdToken}&patient={resp.Patient}";
            return Redirect(successUrl);
            // return Ok(new
            // {
            //     resp,
            //     code,
            //     state
            // });
        }
    }
}