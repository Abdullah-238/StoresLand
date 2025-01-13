using Newtonsoft.Json;
using StoresLand_API;
using StoresLand_API.Persons;
using StoresLand_API.Stores;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace StoresLand_API.Stores
{
    public class StoreDTO
    {
        public int? StoreID { get; set; }
        public string Name { get; set; }
        public string? CommercialNumber { get; set; }
        public int? DistrictsID { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public int? CategoryID { get; set; }
        public int? TypeID { get; set; }
        public byte? Rating { get; set; }
        public decimal? NumberOfRates { get; set; }
        public byte? Status { get; set; }
        public decimal? NumbersOfClick { get; set; }
        public string? Photo { get; set; }
        public int? PeronID { get; set; }


        public string? Phone { get; set; }
        public int? CityID { get; set; }
        public string? Email { get; set; }

        public StoreDTO(int? storeid, string name, string? commercialnumber, int? districtsid, string? website, string? address, int? categoryid,
            int? typeid, byte? rating, decimal? numberofrates, byte? status, decimal? numbersofclick, string? photo, int? peronid, string? phone, int? cityID, string? email)
        {
            this.StoreID = storeid;
            this.Name = name;
            this.CommercialNumber = commercialnumber;
            this.DistrictsID = districtsid;
            this.Website = website;
            this.Address = address;
            this.CategoryID = categoryid;
            this.TypeID = typeid;
            this.Rating = rating;
            this.NumberOfRates = numberofrates;
            this.Status = status;
            this.NumbersOfClick = numbersofclick;
            this.Photo = photo;
            this.PeronID = peronid;
            this.Phone = phone;
            this.CityID = cityID;
            this.Email = email;

        }

    }

    public class StoreDetailsDTO
    {
        public string Name { get; set; }
        public string? RegionName { get; set; }
        public string? CityName { get; set; }
        public string? DistrictsName { get; set; }
        public string? CommercialNumber { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? CategoryName { get; set; }
        public string? TypeName { get; set; }
        public byte? Rating { get; set; }
        public decimal? NumberOfRates { get; set; }
        public string? StoreStatus { get; set; }
        public decimal? NumbersOfClick { get; set; }
        public string? Photo { get; set; }
        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? StoreID { get; set; }

        public StoreDetailsDTO(string name, string? regionName, string? cityName, string? districtsName, string? commercialNumber, string? website, string? address,
            string? categoryName, string? typeName, byte? rating, decimal? numberOfRates, string? storeStatus, decimal? numbersOfClick,
            string? photo, string? personName, string? email, string? phone, int? storeid)
        {
            Name = name;
            RegionName = regionName;
            CityName = cityName;
            DistrictsName = districtsName;
            CommercialNumber = commercialNumber;
            Website = website;
            Address = address;
            CategoryName = categoryName;
            TypeName = typeName;
            Rating = rating;
            NumberOfRates = numberOfRates;
            StoreStatus = storeStatus;
            NumbersOfClick = numbersOfClick;
            Photo = photo;
            PersonName = personName;
            Email = email;
            Phone = phone;
            StoreID = storeid;
        }
    }
    public class clsStore
    {

        public static async Task<StoreDTO> AddStore(StoreDTO store)
        {
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");
                var response = await clsUtil.httpClient.PostAsync($"Stores/AddStore", content);


                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoreDTO>();
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

        public static async Task<StoreDTO> UpdateStore(int? StoreID, StoreDTO store)
        {
            

            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Stores/UpdateStore/{StoreID}", store);

                if (response.IsSuccessStatusCode)
                {
                    var updatedStore = await response.Content.ReadFromJsonAsync<StoreDTO>();
                    if (updatedStore != null)
                        return updatedStore;
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return null;
        }

        public static async Task<StoreDTO> GetStore(int storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/GetStore/{storeID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoreDTO>();
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<StoreDetailsDTO> FindStoreAr(int? storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/FindStoreAr/{storeID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoreDetailsDTO>();
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

        public static async Task<StoreDetailsDTO> FindStoreEn(int? storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/FindStoreEn/{storeID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StoreDetailsDTO>();
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

        public static async Task<bool> DeleteStore(int storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Stores/DeleteStore/{storeID}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return false;
        }
    
        public static async Task<ObservableCollection<StoreDetailsDTO>> GetStoresByCategoryNameAr(string categoryNameAr, int? typeID,int ? PageNumber)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameAr/{categoryNameAr}/{typeID}/{PageNumber}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ObservableCollection<StoreDetailsDTO>>();
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<ObservableCollection<StoreDetailsDTO>> GetStoresByCategoryNameEn(string categoryNameEn, int? typeID,int? PageNumber)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameEn/{categoryNameEn}/{typeID}/{PageNumber}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ObservableCollection<StoreDetailsDTO>>();
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<List<StoreDetailsDTO>> GetAllStoresInDetailsByPersonIDAr(int? PersonID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/GetAllStoresInDetailsByPersonIDAr/{PersonID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }

        public static async Task<List<StoreDetailsDTO>> GetAllStoresInDetailsByPersonIDEn(int? PersonID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Stores/GetAllStoresInDetailsByPersonIDEn/{PersonID}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }

        public static async Task<bool> UpdateStoreRating(byte? Rate, int? StoreID)
        {
            try
            {


                if (!StoreID.HasValue || !Rate.HasValue)
                {
                    return false;
                }

                var response = await clsUtil.httpClient.PutAsJsonAsync($"Stores/UpdateStoreRating/{StoreID}/{Rate}",new {});

                if (response.IsSuccessStatusCode)
                {
                    return true;  
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return false;  // Update failed
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return false;
            }
        }

        public static async Task<bool> UpdateStoreRatingWithOldRate(byte? Rate, byte? OldRate, int? StoreID)
        {
            try
            {
                if (!StoreID.HasValue || !OldRate.HasValue || !Rate.HasValue)
                {
                    return false;
                }

                var response = await clsUtil.httpClient.PutAsJsonAsync( $"Stores/UpdateStoreRatingWithOldRate/{StoreID}/{OldRate}/{Rate}",
                    new { });

                if (response.IsSuccessStatusCode)
                {
                    return true;  
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return false;  
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return false;
            }
        }


    }
}




//public static async Task<List<StoreDTO>> GetAllStores()
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync("Stores/GetAllStores");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError(ex);
//    }
//    return null;
//}
//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryID(int categoryID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryID/{categoryID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError(ex);
//    }
//    return null;
//}

//public static async Task<List<StoreDTO>> GetAllStoresByPersonID(int? PersonID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetAllStoresByPersonID/{PersonID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDTO>>();
//        }
//        else
//        {
//            return null;
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError(ex);
//        return null;
//    }
//}

//public static async Task<List<StoreDetailsDTO>> GetAllStoresInDetailsAr()
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync("Stores/GetAllStoresInDetailsAr");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//        else
//        {
//            return null;
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError(ex);
//        return null;
//    }
//}

//public static async Task<List<StoreDetailsDTO>> GetAllStoresInDetailsEn()
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync("Stores/GetAllStoresInDetailsEn");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//        else
//        {
//            return null;
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError(ex);
//        return null;
//    }
//}


//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryNameArAndRegionNameAr(string categoryNameAr, string regionNameAr, int? typeID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameArAndRegionNameAr/{categoryNameAr}/{regionNameAr}/{typeID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError($"Exception in GetStoresByCategoryNameArAndRegionNameAr: {ex.Message}");
//    }
//    return null;
//}

//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryNameEnAndRegionNameEn(string categoryNameEn, string regionNameEn, int? typeID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameEnAndRegionNameEn/{categoryNameEn}/{regionNameEn}/{typeID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError($"Exception in GetStoresByCategoryNameEnAndRegionNameEn: {ex.Message}");
//    }
//    return null;
//}

//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryNameEnAndCityNameEn(string categoryNameEn, string cityNameEn, int? typeID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameEnAndCityNameEn/{categoryNameEn}/{cityNameEn}/{typeID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError($"Exception in GetStoresByCategoryNameEnAndCityNameEn: {ex.Message}");
//    }
//    return null;
//}

//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryNameArAndCityNameAr(string categoryNameAr, string cityNameAr, int? typeID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameArAndCityNameAr/{categoryNameAr}/{cityNameAr}/{typeID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError($"Exception in GetStoresByCategoryNameArAndCityNameAr: {ex.Message}");
//    }
//    return null;
//}

//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryNameArAndDistrictsNameAr(string categoryNameAr, string districtsNameAr, int? typeID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameArAndDistrictsNameAr/{categoryNameAr}/{districtsNameAr}/{typeID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError($"Exception in GetStoresByCategoryNameArAndDistrictsNameAr: {ex.Message}");
//    }
//    return null;
//}

//public static async Task<List<StoreDetailsDTO>> GetStoresByCategoryNameEnAndDistrictsNameEn(string categoryNameEn, string districtsNameEn, int? typeID)
//{
//    try
//    {
//        var response = await clsUtil.httpClient.GetAsync($"Stores/GetStoresByCategoryNameEnAndDistrictsNameEn/{categoryNameEn}/{districtsNameEn}/{typeID}");
//        if (response.IsSuccessStatusCode)
//        {
//            return await response.Content.ReadFromJsonAsync<List<StoreDetailsDTO>>();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsUtil.WriteExceptionError($"Exception in GetStoresByCategoryNameEnAndDistrictsNameEn: {ex.Message}");
//    }
//    return null;
//}
