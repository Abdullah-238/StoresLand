
using StoresPlace_Front.Stores.StoresMain;

namespace StoresPlace_Front.Stores;


[QueryProperty("CategoryName", "categoryName")]

public partial class pgStores : ContentPage
{

    StoreViewModel store = new StoreViewModel();
    public string CategoryName { get; set; }

    public pgStores()
	{
		InitializeComponent();
    }
    

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        store._Load(CategoryName);

        refresh.IsRefreshing = false;

    }


    private void StorePage_Loaded(object sender, EventArgs e)
    {
        store._Load(CategoryName);

        BindingContext = store;
    }
}