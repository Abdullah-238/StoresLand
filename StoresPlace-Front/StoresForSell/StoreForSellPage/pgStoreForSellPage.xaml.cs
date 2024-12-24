namespace StoresPlace_Front.StoresForSell.StoreForSellPage;

[QueryProperty("StoreID", "storeID")]

public partial class pgStoreForSellPage : ContentPage
{

    StoreForSellViewModel StorePageVM = new StoreForSellViewModel();
    public int StoreID { get; set; }

    public pgStoreForSellPage()
	{
		InitializeComponent();

        StoreForSell.BindingContext = StorePageVM;

    }

    private void StorePage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        StorePageVM.Load(StoreID);

    }

    private void StorePage_Loaded(object sender, EventArgs e)
    {
        StorePageVM.Load(StoreID);

    }
}