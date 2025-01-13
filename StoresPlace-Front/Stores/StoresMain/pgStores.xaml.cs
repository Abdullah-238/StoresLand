using StoresPlace.Global;
using StoresPlace_Front.Stores.StoresMain;
using StoresPlace_Front.Strings;

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
        //store._Load(CategoryName);

        //store.SelectedRegion = string.Empty;

        refresh.IsRefreshing = false;

    }


    private async void StorePage_Loaded(object sender, EventArgs e)
    {
        store._Load(CategoryName);

        BindingContext = store;

        btnIsVisble.IsVisible = true;
    }

    private  void Button_Clicked(object sender, EventArgs e)
    {
        store.LoadMoreStores();


        if (store.Stores.Count > 50)
        {
            MyTool.MyToast(AppStrings.No_other_stores);
        }
    }

}