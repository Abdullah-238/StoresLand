

namespace StoresPlace_Front
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            clsGlobal.CheckForUpdateAsync();

            List<string> images = new List<string>
            {
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-sTiY7igYNP7N0GFqYmJhlqTfno5vyMwa3Q&s",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-sTiY7igYNP7N0GFqYmJhlqTfno5vyMwa3Q&s",
            };

            clvOffers.ItemsSource = images;

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

            clsGlobal.TypeID = 2;

            await Shell.Current.GoToAsync($"Categories");
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            contentPage.Opacity = 0;

            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            clsGlobal.TypeID = 3;

            await Shell.Current.GoToAsync($"Categories");
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
            contentPage.Opacity = 100;
        }
    }

}
