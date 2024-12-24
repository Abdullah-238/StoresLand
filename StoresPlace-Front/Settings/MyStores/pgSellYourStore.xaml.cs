
using StoresLand_API.StoresForSaleServices;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.Settings.MyStores;

[QueryProperty("StoreID", "storeID")]

public partial class pgSellYourStore : ContentPage
{
    public int StoreID { get; set; }

    StoresForSaleDTO StoreForSell; 

    public pgSellYourStore()
	{
		InitializeComponent();
    }

    private async void btAddYourStoreToSell_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(enStorePrice.Text))
        {
            await DisplayAlert(AppStrings.Error, AppStrings.Please_enter_the_price, AppStrings.Ok);
            return;
        }

        if (ckbIsPaid.IsChecked)
            StoreForSell.Status = 2;

        StoreForSell.Price = decimal.Parse(enStorePrice.Text);
        StoreForSell.StoreID = StoreID;
        

        if (await clsStoresForeSaleService.IsStoresForSaleExists(StoreID))
        {
            if (clsStoresForeSaleService.UpdateStoresForSale(StoreForSell.StoreID, StoreForSell) != null)
            {
                ctvActiveIndector1.IsRunning = true;

                await DisplayAlert(AppStrings.Done, AppStrings.The_request_has_been_successfully_submitted, AppStrings.Ok);

                ctvActiveIndector1.IsRunning = false;

            }
            else
            {
                await DisplayAlert(AppStrings.Error, AppStrings.The_request_was_not_submitted_successfully, AppStrings.Ok);
                return;
            }
        }
        else
        {

            if (clsStoresForeSaleService.AddStoresForSale(StoreForSell) != null)
            {
                ctvActiveIndector1.IsRunning = true;

                await DisplayAlert(AppStrings.Done, AppStrings.The_request_has_been_successfully_submitted, AppStrings.Ok);

                ctvActiveIndector1.IsRunning = false;

            }
            else
            {
                await DisplayAlert(AppStrings.Error, AppStrings.The_request_was_not_submitted_successfully, AppStrings.Ok);
                return;
            }
        }
     
        
    }

    async void _Load()
    {
        if (await clsStoresForeSaleService.IsStoresForSaleExists(StoreID))
        {
            StoreForSell = await clsStoresForeSaleService.GetStoresForSale(StoreID);
            enStorePrice.Text = StoreForSell.Price.ToString();

            if (ckbIsPaid.IsChecked)
                StoreForSell.Status = 2;
            else
                StoreForSell.Status = 1;

        }
        else
        {
            StoreForSell = new StoresForSaleDTO(null, null, null, 1);
        }
    }


    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _Load();
    }
}