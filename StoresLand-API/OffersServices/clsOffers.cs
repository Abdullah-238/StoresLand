using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.Offers
{
    public class OfferDTO
    {
        public int? OfferID { get; set; }
        public string Offer { get; set; }
        public int? StoreID { get; set; }

        public OfferDTO(int? offerid, string offer, int? storeid)
        {
            this.OfferID = offerid;
            this.Offer = offer;
            this.StoreID = storeid;

        }
    }

    public class clsOffers
    {
       
        public static async Task<OfferDTO> AddOffer(OfferDTO offerDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("Offer/AddOffer", offerDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<OfferDTO>();
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

        public static async Task<bool> UpdateOffer(int offerID, OfferDTO offerDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Offer/UpdateOffer/{offerID}", offerDTO);

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

        public static async Task<bool> DeleteOffer(int? offerID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Offer/DeleteOffer/{offerID}");

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

        public static async Task<OfferDTO> GetOffer(int offerID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Offer/GetOffer/{offerID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<OfferDTO>();
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

        public static async Task<List<string>> GetAllOfferByStoreID(int? storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Offer/GetAllOfferByStoreID/{storeID}");


                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
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

        public static async Task<ObservableCollection<OfferDTO>> GetAllOfferByStore(int? storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Offer/GetAllOfferByStore/{storeID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ObservableCollection<OfferDTO>>();
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

        public static async Task<bool> IsOfferExists(int offerID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Offer/Exists/{offerID}");

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
