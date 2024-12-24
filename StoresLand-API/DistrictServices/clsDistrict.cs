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


        public static async Task<DistrictDTO> AddDistrict(DistrictDTO district)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("District/AddDistrict", district);

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

        public static async Task<DistrictDTO> UpdateDistrict(int? districtID, DistrictDTO district)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"District/UpdateDistrict/{districtID}", district);

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

        public static async Task<bool> DeleteDistrict(int? districtID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"District/DeleteDistrict/{districtID}");

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

        public static async Task<List<DistrictDTO>> GetAllDistricts()
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

        public static async Task<List<string>> GetDistrictsByCityNameEn(string cityNameEn)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetAllDistrictByCityNameEn/{cityNameEn}");

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

        public static async Task<List<string>> GetDistrictsByCityNameAr(string cityNameAr)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetAllDistrictByCityNameAr/{cityNameAr}");

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

        public static async Task<string> GetDistrictsNameEnByDistrictsID(int? DistrictsID)
        {
            string DistrictsName = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetDistrictsNameEnByDistrictsID/{DistrictsID}");

                if (response.IsSuccessStatusCode)
                {
                    DistrictsName = await response.Content.ReadAsStringAsync();
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
            return DistrictsName;
        }

        public static async Task<string> GetDistrictsNameArByDistrictsID(int? DistrictsID)
        {
            string DistrictsName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetDistrictsNameEnByDistrictsID/{DistrictsID}");


                if (response.IsSuccessStatusCode)
                {
                    DistrictsName = await response.Content.ReadAsStringAsync();
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

            return DistrictsName;

        }

        public static async Task<int?> GetDistrictsIDByDistrictNameAr(string DistrictNameAr)
        {
            int? districtID = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetDistrictsIDByDistrictNameAr/{DistrictNameAr}");

                if (response.IsSuccessStatusCode)
                {
                    districtID = await response.Content.ReadFromJsonAsync<int?>();
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
            return districtID;
        }

        public static async Task<int?> GetDistrictsIDByDistrictNameEn(string DistrictNameEn)
        {
            int? districtID = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"District/GetDistrictsIDByDistrictNameEn/{DistrictNameEn}");

                if (response.IsSuccessStatusCode)
                {
                    districtID = await response.Content.ReadFromJsonAsync<int?>();
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
            return districtID;
        }

    }

}

