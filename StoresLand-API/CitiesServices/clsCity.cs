using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.CitiesServices
{
    public class CityDTO
    {
        public int? CityID { get; set; }
        public string CityNameAr { get; set; }
        public string CityNameEn { get; set; }
        public int? RegionID { get; set; }

        public CityDTO(int? cityid, string citynamear, string citynameen, int? regionid)
        {
            this.CityID = cityid;
            this.CityNameAr = citynamear;
            this.CityNameEn = citynameen;
            this.RegionID = regionid;

        }
    }
    public class clsCity
    {

        public static async Task<List<CityDTO>> GetAllCities()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("City/GetAllCities");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<CityDTO>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

    }

}

