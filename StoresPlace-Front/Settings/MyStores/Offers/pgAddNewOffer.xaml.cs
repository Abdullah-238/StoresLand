using StoresLand_API.Offers;
using StoresPlace.Global;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.Settings.MyStores;

[QueryProperty("StoreID", "storeID")]

[QueryProperty("OfferID", "offerID")]

public partial class pgAddNewOffer : ContentPage
{
	public int StoreID { get; set; }  
    public int OfferID { get; set; }


    OfferDTO offer;
    public pgAddNewOffer()
	{
		InitializeComponent();

    }

    async void _Load()
    {
        if (OfferID > 0 )
        {
            offer = await clsOffers.GetOffer(OfferID);
            enOffer.Text = offer.Offer;
        }
        else
        {
            offer = new OfferDTO(null, "", null);
        }
    }

    private async void btAddNewOffer_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(enOffer.Text))
        {
            await DisplayAlert(AppStrings.Done, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);
            return;
        }

        offer.StoreID = StoreID;
        offer.Offer = enOffer.Text;

        if (OfferID > 0)
        {
            if (await clsOffers.UpdateOffer(OfferID, offer) != null)
            {
                ctvActiveIndector1.IsRunning = true;

                await Task.Delay(10);

                MyTool.MyToast(AppStrings.Your_offer_has_been_added_successfully);

                ctvActiveIndector1.IsRunning = false;
            }
            else
            {
                await DisplayAlert(AppStrings.Error, AppStrings.Your_offer_has_been_added_falied, AppStrings.Ok);
                return;
            }
        }
        else
        {
            if (clsOffers.AddOffer(offer) != null)
            {
                ctvActiveIndector1.IsRunning = true;

                await Task.Delay(10);

                MyTool.MyToast(AppStrings.Your_offer_has_been_added_successfully);

                ctvActiveIndector1.IsRunning = false;

            }
            else
            {
                await DisplayAlert(AppStrings.Error, AppStrings.Your_offer_has_been_added_falied, AppStrings.Ok);
                return;
            }


           
        }



       
    }


    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _Load();
    }
}