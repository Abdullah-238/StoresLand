using StoresLand_API.CouponsServices;
using StoresLand_API.Offers;
using StoresPlace.Global;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.Settings.MyStores;


[QueryProperty("StoreID", "storeID")]

[QueryProperty("CouponID", "couponID")]
public partial class pgAddNewCoupoun : ContentPage
{
  
    public int StoreID { get; set; }

    public int CouponID { get; set; }

    CouponDTO coupon;

    public pgAddNewCoupoun()
	{
		InitializeComponent();
    }

    async void _Load()
    {
        if (CouponID > 0)
        {
            coupon = await clsCoupon.GetCoupon(CouponID);
            enCoupon.Text = coupon.Coupon;
        }
        else
        {
            dtpExpiredDate.MinimumDate = DateTime.Now;

            coupon =new CouponDTO(null, null,null,DateTime.Now,false);
        }
    }


    private async void btAddNewCoupoun_Clicked(object sender, EventArgs e)
    {
      
        if (string.IsNullOrEmpty(enCoupon.Text))
        {
            await DisplayAlert(AppStrings.Done, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);
            return;
        }

        coupon.StoreID = StoreID;
        coupon.ExpiryDate = dtpExpiredDate.Date;
        coupon.Coupon = enCoupon.Text;

        if (ckbIsActive.IsChecked)
        {
            coupon.IsActive = true;
        }
        else
        {
            coupon.IsActive = false;
        }


        if (CouponID > 0)
        {
            var newCoupon = await clsCoupon.UpdateCoupon(CouponID, coupon);

            if (newCoupon != null)
            {
                ctvActiveIndector1.IsRunning = true;

                await Task.Delay(10);

                MyTool.MyToast(AppStrings.Your_Coupon_has_been_added_successfully);

                ctvActiveIndector1.IsRunning = false;
            }
            else
            {
                await DisplayAlert(AppStrings.Error, AppStrings.Your_Coupon_has_been_added_falied, AppStrings.Ok);
                return;
            }
        }
        else
        {
            if (clsCoupon.AddCoupon(coupon) != null)
            {
                ctvActiveIndector1.IsRunning = true;

                await Task.Delay(10);

                MyTool.MyToast(AppStrings.Your_Coupon_has_been_added_successfully);

                ctvActiveIndector1.IsRunning = false;

            }

            else
            {
                await DisplayAlert(AppStrings.Error, AppStrings.Your_Coupon_has_been_added_falied, AppStrings.Ok);
                return;
            }
        }

    }
       
  

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _Load();
    }

  
}