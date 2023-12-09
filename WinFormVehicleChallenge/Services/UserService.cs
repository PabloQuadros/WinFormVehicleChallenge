using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WinFormVehicleChallenge.Services;

public class UserService
{
    public async Task<bool> SignIn(string user, string password)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://test-api-y04b.onrender.com/signIn";
                var parameters = new
                {
                    user = user,
                    password = password
                };

                string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);

                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                response.EnsureSuccessStatusCode();
                
                string responseBody = await response.Content.ReadAsStringAsync();

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

                bool error = Convert.ToBoolean(result["error"]);
                
                if (error)
                {
                    string message = result.ContainsKey("message") ? result["message"].ToString() : "Erro desconhecido";
                    throw new Exception(message);
                }

                return true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
