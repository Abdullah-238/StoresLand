using System.Net.Http.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json.Serialization;


namespace StoresLand_API.StoresForSaleServices
{
    public class StoresForSaleDTO
    {
        public int? StoreForSaleID { get; set; }
        public int? StoreID { get; set; }
        public decimal? Price { get; set; }
        public byte? Status { get; set; }

        public StoresForSaleDTO(int? storeforsaleid, int? storeid, decimal? price, byte? status)
        {
            this.StoreForSaleID = storeforsaleid;
            this.StoreID = storeid;
            this.Price = price;
            this.Status = status;

        }
    }

    public class StoresForSaleDetailsDTO
    {
        public string Name { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string DistrictsName { get; set; }
        public string CommercialNumber { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string CategoryName { get; set; }
        public string TypeName { get; set; }
        public byte? Rating { get; set; }
        public decimal? NumberOfRates { get; set; }
        public string StoreStatus { get; set; }
        public decimal? NumbersOfClick { get; set; }
        public string Photo { get; set; }
        public string PersonName { get; set; }
        public int? StoreID { get; set; }

        public decimal? Price { get; set; }

        public string StoresForSaleStatus { get; set; }

        public StoresForSaleDetailsDTO(string name, string regionNameAr, string cityNameAr, string districtsNameAr, string commercialNumber, string website, string address,
            string categoryNameAr, string typeNameAr, byte? rating, decimal? numberOfRates, string storeStatus, decimal? numbersOfClick, string photo, string personName,
            int? storeid, decimal? price, string storesForsalestatus)
        {
            Name = name;
            RegionName = regionNameAr;
            CityName = cityNameAr;
            DistrictsName = districtsNameAr;
            CommercialNumber = commercialNumber;
            Website = website;
            Address = address;
            CategoryName = categoryNameAr;
            TypeName = typeNameAr;
            Rating = rating;
            NumberOfRates = numberOfRates;
            StoreStatus = storeStatus;
            NumbersOfClick = numbersOfClick;
            Photo = photo;
            PersonName = personName;
            StoreID = storeid;
            Price = price;
            StoresForSaleStatus = storesForsalestatus;
        }
    }
    public class clsStoresForeSaleService
    {


        public static async Task<StoresForSaleDTO> AddStoresForSale(StoresForSaleDTO storesForSaleDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("StoresForSale/AddStoresForSale", storesForSaleDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoresForSaleDTO>();
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

        public static async Task<StoresForSaleDTO> UpdateStoresForSale(int? storeForSaleID, StoresForSaleDTO storesForSaleDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"StoresForSale/UpdateStoresForSale/{storeForSaleID}", storesForSaleDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoresForSaleDTO>();
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

        public static async Task<bool> DeleteStoresForSale(int storeForSaleID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"StoresForSale/DeleteStoresForSale/{storeForSaleID}");

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

        public static async Task<StoresForSaleDTO> GetStoresForSale(int storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"StoresForSale/GetStoresForSale/{storeID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoresForSaleDTO>();
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

        public static async Task<List<StoresForSaleDetailsDTO>> GetAllStoresForSaleAr()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("StoresForSale/GetAllStoresForSaleAr");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var storesForSale = JsonConvert.DeserializeObject<List<StoresForSaleDetailsDTO>>(responseBody);

                    //return await response.Content.ReadFromJsonAsync<List<StoresForSaleDetailsDTO>>();

                    if (storesForSale != null)
                        return storesForSale;
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }

            return null;

        }

        public static async Task<List<StoresForSaleDetailsDTO>> GetAllStoresForSaleEn()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("StoresForSale/GetAllStoresForSaleEn");

                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var storesForSale = JsonConvert.DeserializeObject<List<StoresForSaleDetailsDTO>>(responseBody);

                    //return await response.Content.ReadFromJsonAsync<List<StoresForSaleDetailsDTO>>();

                    if (storesForSale != null)
                        return storesForSale;
                  
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

            return null;
        }

        public static async Task<bool> IsStoresForSaleExists(int storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"StoresForSale/Exists/{storeID}");

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
    }

}

