using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.AppSettingsServices
{
    public class clsAppSettings
    {
        public static async Task<string> GetVersionStringAsync()
        {
            try
            {
                // Send GET request to the API
                var response = await clsUtil.httpClient.GetAsync($"AppSettings/GetVersionString");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
