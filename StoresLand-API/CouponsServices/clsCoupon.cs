using StoresLand_API.Persons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.CouponsServices
{
    public class CouponDTO
    {
        public int? CouponID { get; set; }
        public string Coupon { get; set; }
        public int? StoreID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        public CouponDTO(int? couponid, string coupon, int? storeid, DateTime expirydate, bool isactive)
        {
            this.CouponID = couponid;
            this.Coupon = coupon;
            this.StoreID = storeid;
            this.ExpiryDate = expirydate;
            this.IsActive = isactive;

        }
    }

    public class clsCoupon
    {

        public static async Task<CouponDTO> AddCoupon(CouponDTO coupon)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("Coupons/AddCoupon", coupon);
                if (response.IsSuccessStatusCode)
                {
                    var addedCoupon = await response.Content.ReadFromJsonAsync<CouponDTO>();
                    return addedCoupon;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<CouponDTO> UpdateCoupon(int? couponID, CouponDTO coupon)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Coupons/UpdateCoupon/{couponID}", coupon);
                if (response.IsSuccessStatusCode)
                {

                    var newCoupon = await response.Content.ReadFromJsonAsync<CouponDTO>();

                    if (newCoupon != null)
                        return newCoupon;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<CouponDTO> GetCoupon(int? couponID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Coupons/GetCoupon/{couponID}");
                if (response.IsSuccessStatusCode)
                {
                    var coupon = await response.Content.ReadFromJsonAsync<CouponDTO>();
                    return coupon;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<bool> DeleteCoupon(int? couponID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Coupons/DeleteCoupon/{couponID}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return false;
        }

        public static async Task<ObservableCollection<CouponDTO>> GetCouponsByStoreID(int? storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Coupons/GetCouponsByStore/{storeID}");
                if (response.IsSuccessStatusCode)
                {
                    var coupons = await response.Content.ReadFromJsonAsync<ObservableCollection<CouponDTO>>();
                    return coupons;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<List<string>> GetAllCouponsByStoreID(int? storeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Coupons/GetCouponCodesByStore/{storeID}");
                if (response.IsSuccessStatusCode)
                {
                    var couponNames = await response.Content.ReadFromJsonAsync<List<string>>();
                    return couponNames;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }
    }

}

