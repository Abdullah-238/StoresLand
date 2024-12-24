using Microsoft.Maui.Controls.Platform;
using StoresLand_API;
using StoresLand_API.Persons;
using StoresPlace_Front.Global;
using StoresPlace_Front.Main;

namespace StoresPlace_Front
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new pgIntroUser());

            MainPage.IsVisible = false;

            _InitializeAppAsync();
        }

        private async Task _InitializeAppAsync()
        {
            _LoadAppTheme();

            await _LoginOptionAsync();
        }

        async Task _LoginOptionAsync()
        {
            if (Preferences.ContainsKey(clsAppConstants.Email) && Preferences.ContainsKey(clsAppConstants.Password))
            {
                string Email = clsUtil.Decrypt(Preferences.Default.Get(clsAppConstants.Email, ""));
                string Password = clsUtil.Decrypt(Preferences.Default.Get(clsAppConstants.Password, ""));

                Person customer = await clsPerson.FindPersonByEmailAndPassword(Email, Password);

                if (customer != null)
                {
                    clsGlobal.CurrentUser = customer;
                    Application.Current.MainPage = new AppShell();
                    return;
                }
            }

            MainPage.IsVisible = true;

            MainPage = new NavigationPage(new pgIntroUser());

            //Application.Current.MainPage = new NavigationPage(new pgIntroUser());

        }

        void _LoadAppTheme()
        {
            string Mode = Preferences.Default.Get("Mode", "");


            switch (Mode)
            {
                case "Default":
                    Application.Current.UserAppTheme = AppTheme.Unspecified;
                    break;
                case "Dark":
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    break;
                case "Light":
                    Application.Current.UserAppTheme = AppTheme.Light;
                    break;
                default:
                    Application.Current.UserAppTheme = AppTheme.Unspecified;
                    break;
            }
        }
    }
}
