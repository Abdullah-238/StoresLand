using Newtonsoft.Json;
using StoresLand_API.StoresForSaleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.DistrictServices
{
    public class DistrictDTO
    {
        public int? DistrictsID { get; set; }
        public int? CityID { get; set; }
        public string DistrictsNameAr { get; set; }
        public string DistrictsNameEn { get; set; }

        public DistrictDTO(int? districtsid, int? cityid, string districtsnamear, string districtsnameen)
        {
            this.DistrictsID = districtsid;
            this.CityID = cityid;
            this.DistrictsNameAr = districtsnamear;
            this.DistrictsNameEn = districtsnameen;

        }
    }
    public class clsDistrict
    {


     
        public static async Task<DistrictDTO> GetDistrict(int? districtID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetDistrict/{districtID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<DistrictDTO>();
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

        public static async Task<List<DistrictDTO>> GetAllDistrictsAsync()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("District/GetAllDistricts");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<DistrictDTO>>();
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

