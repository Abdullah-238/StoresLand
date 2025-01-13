using StoresLand_API.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static StoresLand_API.Stores.clsStore;

namespace StoresLand_API.SavedStoresServices
{
    public class SavedStoreDTO
    {
        public int? StoreSavedId { get; set; }
        public int? StoreID { get; set; }
        public int? PersonID { get; set; }

        public SavedStoreDTO(int? storesavedid, int? storeid, int? personid)
        {
            this.StoreSavedId = storesavedid;
            this.StoreID = storeid;
            this.PersonID = personid;

        }
    }
    public class clsSavedStore
    {
      

        public static async Task<SavedStoreDTO> AddSavedStore(SavedStoreDTO savedStoreDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("SavedStores/AddSavedStore", savedStoreDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<SavedStoreDTO>();
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

        public static async Task<bool> UpdateSavedStore(int storeSavedId, SavedStoreDTO savedStoreDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"SavedStores/UpdateSavedStore/{storeSavedId}", savedStoreDTO);

                if (response.IsSuccessStatusCode)
                {
                    return true;
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

            return false;

        }

        public static async Task<bool> DeleteSavedStore(int? storeSavedId)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"SavedStores/DeleteSavedStore/{storeSavedId}");

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

        public static async Task<bool> DeleteSavedStoreByStoreID(int storeSavedId, int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"SavedStores/DeleteSavedStoreByStoreID/{storeSavedId}/{personID}");

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

        public static async Task<SavedStoreDTO> GetSavedStore(int? storeSavedId)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"SavedStores/GetSavedStore/{storeSavedId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<SavedStoreDTO>();
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

        public static async Task<List<SavedStoreDTO>> GetAllSavedStores()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("SavedStores/GetAllSavedStores");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<SavedStoreDTO>>();
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

        public static async Task<ObservableCollection<StoreDetailsDTO>> GetSavedStoreByPersonIDAr(int? personID, int? PageNumber)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"SavedStores/GetSavedStoreByPersonIDAr/{personID}/{PageNumber}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ObservableCollection<StoreDetailsDTO>>();
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

        public static async Task<ObservableCollection<StoreDetailsDTO>> GetSavedStoreByPersonIDEn(int? personID, int? PageNumber)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"SavedStores/GetSavedStoreByPersonIDEn/{personID}/{PageNumber}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ObservableCollection<StoreDetailsDTO>>();
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

        public static async Task<bool> IsSavedStoreExists(int? storeSavedId)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"SavedStores/Exists/{storeSavedId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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

        public static async Task<bool> IsSavedStoreExistsByStoreAndPerson(int? storeID, int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"SavedStores/ExistsByStoreAndPerson/{storeID}/{personID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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
