

using StoresPlace_Front.Stores.StoresPage;

namespace StoresPlace_Front.Stores;

[QueryProperty("StoreID", "storeID")]

public partial class pgStorePage : ContentPage
{


    StorePageViewModel StorePageVM = new StorePageViewModel();
    public int StoreID { get; set; }

    public pgStorePage()
	{
		InitializeComponent();

        StorePage.BindingContext = StorePageVM;

    }



    private void StorePage_Appearing(object sender, EventArgs e)
    {
      
    }

    private void StorePage_Loaded(object sender, EventArgs e)
    {
        StorePageVM.Load(StoreID);

    }

   

    private void StorePage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        StorePageVM.Load(StoreID);

    }
}