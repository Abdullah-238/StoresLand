using StoresLand_API.Categories;
using StoresLand_API.CitiesServices;
using StoresLand_API.DistrictServices;
using StoresLand_API.RegionsServices;
using StoresLand_API.TypesServices;
using StoresPlace_Front.Sqlite;
using StoresPlace_Front.Sqlite.Regions;


namespace StoresPlace_Front
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // SaveDataAsync();

            clsGlobal.CheckForUpdateAsync();

            //List<string> images = new List<string>
            //{
            //"http://storesland.com/Images/offer1.png",
            //"http://storesland.com/Images/offer2.png",
            //};

            //clvOffers.ItemsSource = images;


            

        }


        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            //await Navigation.PushAsync(new pgCategories());

            contentPage.Opacity = 0;

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            clsGlobal.TypeID = 1;

            await Shell.Current.GoToAsync($"Categories");
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            contentPage.Opacity = 0;

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            clsGlobal.TypeID = 3;

            await Shell.Current.GoToAsync($"Categories");
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            contentPage.Opacity = 0;

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            clsGlobal.TypeID = 2;

            await Shell.Current.GoToAsync($"Categories");
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
            contentPage.Opacity = 100;
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {
            contentPage.Opacity = 0;

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            clsGlobal.TypeID = 3;

            await Shell.Current.GoToAsync($"Categories");
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
        {
            contentPage.Opacity = 0;

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            clsGlobal.TypeID = 4;

            await Shell.Current.GoToAsync($"Categories");
        }



    }
}


