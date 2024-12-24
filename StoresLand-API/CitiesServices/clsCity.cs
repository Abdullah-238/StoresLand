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

        public static async Task<CityDTO> AddCity(CityDTO city)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("City/AddCity", city);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CityDTO>();
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

        public static async Task<CityDTO> UpdateCity(int? cityID, CityDTO city)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"City/UpdateCity/{cityID}", city);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CityDTO>();
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

        public static async Task<bool> DeleteCity(int? cityID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"City/DeleteCity/{cityID}");

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

        public static async Task<CityDTO> GetCity(int? cityID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"City/GetCity/{cityID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CityDTO>();
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

        public static async Task<List<CityDTO>> GetCitiesByRegion(int? regionID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"City/GetCitiesByRegion/{regionID}");

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

        public static async Task<List<string>> GetAllCitiesByRegionNameAr(string regionNameAr)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"City/GetCitiesByRegionNameAr/{regionNameAr}");

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

        public static async Task<List<string>> GetAllCitiesByRegionNameEn(string regionNameEn)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"City/GetCitiesByRegionNameEn/{regionNameEn}");

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

        public static async Task<string> GetCityNameArByDistrictsID(int? DistrictsID)
        {
            string CityName = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"City/GetCityNameEnByDistrictsID/{DistrictsID}");

                if (response.IsSuccessStatusCode)
                {
                    CityName = await response.Content.ReadAsStringAsync();
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
            return CityName;
        }

        public static async Task<string> GetCityNameEnByDistrictsID(int? DistrictsID)
        {
            string CityName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"City/GetCityNameEnByDistrictsID/{DistrictsID}");

                if (response.IsSuccessStatusCode)
                {
                    CityName = await response.Content.ReadAsStringAsync();
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
            return CityName;

        }



    }

}

