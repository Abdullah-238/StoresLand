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

        public static async Task<RegionDTO> AddRegion(RegionDTO region)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("Region/AddRegion", region);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RegionDTO>();
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

        public static async Task<RegionDTO> UpdateRegion(int regionID, RegionDTO region)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Region/UpdateRegion/{regionID}", region);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RegionDTO>();
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

        public static async Task<bool> DeleteRegion(int? regionID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Region/DeleteRegion/{regionID}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return false;
            }
        }

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

        public static async Task<List<string>> GetAllRegionsByNameAr()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Region/GetAllRegionsByNameAr");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
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

        public static async Task<List<string>> GetAllRegionsByNameEn()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Region/GetAllRegionsByNameEn");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
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

        public static async Task<string> GetRegionNameArByRegionID(int? RegionID)
        {
            string RegionName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Region/GetRegionNameArByRegionID/{RegionID}");

                if (response.IsSuccessStatusCode)
                {
                    RegionName =  await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return RegionName;
        }

        public static async Task<string> GetRegionNameEnByRegionID(int? RegionID)
        {
            string RegionName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Region/GetRegionNameEnByRegionID/{RegionID}");

                if (response.IsSuccessStatusCode)
                {
                    RegionName = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return RegionName;

        }

        public static async Task<string> GetRegionNameArByDistrictsID(int? DistrictsID)
        {

            string RegionName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Region/GetRegionNameArByDistrictsID/{DistrictsID}");

                if (response.IsSuccessStatusCode)
                {
                    RegionName = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return RegionName;
        }

        public static async Task<string> GetRegionNameEnByDistrictsID(int? DistrictsID)
        {
            string RegionName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Region/GetRegionNameEnByDistrictsID/{DistrictsID}");

                if (response.IsSuccessStatusCode)
                {
                    RegionName = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return RegionName;

        }

    }

}

