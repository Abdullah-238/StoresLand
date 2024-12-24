using StoresPlace_Front.StoresForSell.StoresForSell;

namespace StoresPlace_Front.StoresForSell;

public partial class pgStoresForSell : ContentPage
{

    StoresForSellViewModel store = new StoresForSellViewModel();

    public pgStoresForSell()
	{
		InitializeComponent();

        this.BindingContext = store;

    }

    private void StorePage_Loaded(object sender, EventArgs e)
    {
        store._Load();
    }

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        refresh.IsRefreshing =  false;

        store._Load();

    }
}