using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.RegionsServices
{
    public class RegionDTO
    {
        public int? RegionID { get; set; }
        public string Code { get; set; }
        public string RegionNameAr { get; set; }
        public string RegionNameEn { get; set; }

        public RegionDTO(int? regionid, string code, string regionnamear, string regionnameen)
        {
            this.RegionID = regionid;
            this.Code = code;
            this.RegionNameAr = regionnamear;
            this.RegionNameEn = regionnameen;

        }
    }
    public class clsRegion
    {

     
        public static async Task<RegionDTO> GetRegion(int? regionID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Region/GetRegion/{regionID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RegionDTO>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }

        public static async Task<List<RegionDTO>> GetAllRegions()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Region/GetAllRegions");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<RegionDTO>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }

    }

}

