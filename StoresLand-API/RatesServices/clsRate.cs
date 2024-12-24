using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.Rates
{
    public class RateDTO
    {
        public int? RateID { get; set; }
        public int? StoreID { get; set; }
        public string Comment { get; set; }
        public byte? Rate { get; set; }
        public int? PersonID { get; set; }

        public RateDTO(int? rateid, int? storeid, string comment, byte? rate, int? personid)
        {
            this.RateID = rateid;
            this.StoreID = storeid;
            this.Comment = comment;
            this.Rate = rate;
            this.PersonID = personid;

        }

    }

    public class clsRate
    {
       
        public static async Task<RateDTO> AddRate(RateDTO rateDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("Rates/AddRate", rateDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RateDTO>();
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

        public static async Task<bool> UpdateRate(int? rateID, RateDTO rateDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Rates/UpdateRate/{rateID}", rateDTO);

                if (response.IsSuccessStatusCode)
                {
                    return true;
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
            return false;
        }

        public static async Task<bool> DeleteRate(int rateID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Rates/DeleteRate/{rateID}");

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

        public static async Task<RateDTO> GetRate(int rateID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Rates/GetRate/{rateID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RateDTO>();
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

        public static async Task<List<RateDTO>> GetAllRates()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Rates/GetAllRates");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<RateDTO>>();
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

        public static async Task<bool> IsRateExists(int rateID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Rates/Exists/{rateID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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

        public static async Task<bool> IsRateExistsByStoreAndPerson(int? storeID, int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Rates/ExistsByStoreAndPerson/{storeID}/{personID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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

        public static async Task<RateDTO> GetRateByStoreAndPerson(int? storeID, int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Rates/GetRateByStoreAndPerson/{storeID}/{personID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RateDTO>();
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
