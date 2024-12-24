using StoresLand_API.Rates;
using StoresLand_API.Stores;
using StoresPlace.Global;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.Stores.Rateing;

[QueryProperty("StoreID", "storeID")]

public partial class pgAddNewRate : ContentPage
{
    public int StoreID {  get; set; }

    byte? _OrderRate = 1;

    byte? _OldRate = null; 
   
    RateDTO rate;

    bool isRated = false;
    public pgAddNewRate()
	{
		InitializeComponent();
    }


    async void _Load()
    {
         isRated = await clsRate.IsRateExistsByStoreAndPerson(StoreID, clsGlobal.CurrentUser.PersonID);

        if (isRated)
        {
            rate = await clsRate.GetRateByStoreAndPerson(StoreID,clsGlobal.CurrentUser.PersonID);

            edtDesc.Text = rate.Comment; 

            switch(rate.Rate)
            {
                case 1:
                    sta_Clicked(null, null);
                    break;
                case 2:
                    star2_Clicked(null, null);
                    break;
                case 3:
                    star3_Clicked(null, null);
                    break;
                case 4:
                    star4_Clicked(null, null);
                    break;
                case 5:
                    star5_Clicked(null, null);
                    break;
            }

            _OldRate = rate.Rate;
        }
        else
        {
             rate = new RateDTO(null, StoreID, edtDesc.Text, _OrderRate, clsGlobal.CurrentUser.PersonID);
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(edtDesc.Text))
        {
            await DisplayAlert(AppStrings.Done, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);
            return;
        }

        rate.Comment = edtDesc.Text.Trim();
        rate.Rate = _OrderRate;



        if (!isRated)
        {
            if (clsRate.AddRate(rate) != null)
            {
                if (await clsStore.UpdateStoreRating(_OrderRate, StoreID))
                {
                    btCreate.IsEnabled = false;

                    MyTool.MyToast(AppStrings.Thank_you_for_your_rating);
                }
                else
                {
                    MyTool.MyToast(AppStrings.Please_try_again_later);
                }
            }   
        }
        else
        {
            if (await clsStore.UpdateStoreRatingWithOldRate(_OrderRate, _OldRate, StoreID))
            {
                if (await clsRate.UpdateRate(rate.RateID, rate))
                {
                    btCreate.IsEnabled = false;

                    MyTool.MyToast(AppStrings.Thank_you_for_your_rating);
                }
                else
                {
                    MyTool.MyToast(AppStrings.Please_try_again_later);
                }
            }
            else
            {
                MyTool.MyToast(AppStrings.Please_try_again_later);
            }
        }
    }

    private void sta_Clicked(object sender, EventArgs e)
    {
        star2.Source = "star_empty";
        star3.Source = "star_empty";
        star4.Source = "star_empty";
        star5.Source = "star_empty";

        _OrderRate = 1;
    }

    private void star2_Clicked(object sender, EventArgs e)
    {
        star2.Source = "star";
        star3.Source = "star_empty";
        star4.Source = "star_empty";
        star5.Source = "star_empty";

        _OrderRate = 2;
    }

    private void star3_Clicked(object sender, EventArgs e)
    {
        star2.Source = "star";
        star3.Source = "star";
        star4.Source = "star_empty";
        star5.Source = "star_empty";

        _OrderRate = 3;
    }

    private void star4_Clicked(object sender, EventArgs e)
    {
        star2.Source = "star";
        star3.Source = "star";
        star4.Source = "star";
        star5.Source = "star_empty";

        _OrderRate = 4;
    }

    private void star5_Clicked(object sender, EventArgs e)
    {
        star2.Source = "star";
        star3.Source = "star";
        star4.Source = "star";
        star5.Source = "star";

        _OrderRate = 5;
    }



    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        _Load();

    }
}