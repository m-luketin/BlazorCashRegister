using BlazorCashRegister.Data.Entities.Models;
using Jose;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BlazorCashRegister.Domain.Helpers
{
    public class JwtHelper
    {
        public JwtHelper(IConfiguration configuration)
        {
            _issuer = configuration["JWT:Issuer"];
            _audienceId = configuration["JWT:AudienceId"];
            _secret = Encoding.UTF8.GetBytes(configuration["JWT:AudienceSecret"].ToString());
        }

        private readonly string _issuer;
        private readonly string _audienceId;
        private readonly byte[] _secret;
        public string GetJwtToken(Employee employeeToGenerateFor)
        {
            var currentSeconds = Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var payload = new Dictionary<string, string>
            {
                {"iss", _issuer},
                {"aud", _audienceId},
                {"exp", (currentSeconds + 300).ToString(CultureInfo.InvariantCulture) },
                {"employeeid", employeeToGenerateFor.EmployeeId.ToString()},
                {"name", $"{employeeToGenerateFor.Name}"},
                {"role", "Employee" }
            };
                
            return JWT.Encode(payload, _secret, JwsAlgorithm.HS256);
        }

        public int GetEmployeeIdFromToken(string token)
        {
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(JWT.Decode(token, _secret));
            var didParsingSucceed = int.TryParse(decodedJObjectToken["employeeid"].ToString(), out int employeeId);
            if(didParsingSucceed)
                return employeeId;
            return 0;
        }

        public string GetNewToken(string existingToken)
        {
            var decodedToken = JWT.Decode(existingToken, _secret);
            var decodedJObjectToken = (JObject)JsonConvert.DeserializeObject(decodedToken);
            var currentSeconds = Math.Round(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            var expiryTime = decodedJObjectToken["exp"].ToObject<double>();

            if(currentSeconds - expiryTime > 86400)
                return null;

            var payload = new Dictionary<string, string>
            {
                {"iss", decodedJObjectToken["iss"].ToString() },
                {"aud", decodedJObjectToken["aud"].ToString()},
                {"exp", (currentSeconds + 300).ToString(CultureInfo.InvariantCulture) },
                {"employeeid", decodedJObjectToken["employeeid"].ToString()},
                {"name", decodedJObjectToken["name"].ToString()},
                {"role", decodedJObjectToken["role"].ToString() }
            };

            return JWT.Encode(payload, _secret, JwsAlgorithm.HS256);
        }
    }
}
