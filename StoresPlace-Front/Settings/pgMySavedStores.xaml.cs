using StoresPlace_Front.Settings.SettingsViewModel;
using StoresPlace_Front.Stores.StoresMain;

namespace StoresPlace_Front.Settings;

public partial class pgMySavedStores : ContentPage
{
    StoreViewModel clsMyStoreViewModel = new StoreViewModel();

    public pgMySavedStores()
	{
		InitializeComponent();
	}

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        clsMyStoreViewModel.LoadSavedStores();

        refresh.IsRefreshing = false;
    }

    private void PersonStore_Appearing(object sender, EventArgs e)
    {
        clsMyStoreViewModel.LoadSavedStores();

        this.BindingContext = clsMyStoreViewModel;
    }
}