using StoresLand_API.Stores;
using StoresPlace.Global;
using StoresPlace_Front.Settings.MyStores.MyStore.MyStoreViewModel;
using StoresPlace_Front.Stores;
using StoresPlace_Front.Strings;
using System.Globalization;

namespace StoresPlace_Front.Settings.MyStores;

[QueryProperty("StoreID", "storeID")]

public partial class pgMyStorePage : ContentPage
{
    MyStorePageViewModel StorePageVM = new MyStorePageViewModel();
    public int StoreID { get; set; }
    public pgMyStorePage()
	{
		InitializeComponent();

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
       
    }

 
    private async void btUpdateStore_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"AddNewStore?storeID={StoreID}");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync($"AddNewOffer?storeID={StoreID}");
    }

    private void StorePage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        LoadingIndicator.IsVisible = false;
        LoadingIndicator.IsRunning = false;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"AddNewCoupon?storeID={StoreID}");
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        bool Delete = await AppShell.Current.DisplayAlert(AppStrings.Delete_Account, AppStrings.Are_you_sure_you_want_to_delete_your_store, AppStrings.Ok, AppStrings.Cancel);

        if (Delete)
        {
            if (await clsStore.DeleteStore(StoreID))
            {
                await AppShell.Current.DisplayAlert(AppStrings.Done, AppStrings.The_store_has_been_deleted_successfully, AppStrings.Ok);

                await Shell.Current.GoToAsync("..");

            }
            else
                MyTool.MyToast(AppStrings.The_store_has_not_been_deleted_successfully);
        }
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"SellYourStore?storeID={StoreID}");
    }


    private void StorePage_Appearing(object sender, EventArgs e)
    {

        StorePageVM.Load(StoreID);

        StorePage.BindingContext = StorePageVM;

    }
}