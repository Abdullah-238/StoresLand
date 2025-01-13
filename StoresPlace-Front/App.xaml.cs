using Microsoft.Maui.Controls.Platform;
using StoresLand_API;
using StoresLand_API.Categories;
using StoresLand_API.CitiesServices;
using StoresLand_API.DistrictServices;
using StoresLand_API.Persons;
using StoresLand_API.RegionsServices;
using StoresLand_API.TypesServices;
using StoresPlace_Front.Global;
using StoresPlace_Front.Main;
using StoresPlace_Front.Sqlite;
using StoresPlace_Front.Sqlite.Regions;

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

            await SaveDataAsync();
        }


        public async Task SaveDataAsync()
        {

            if (!clsRegionLite.TableExists())
            {
                List<RegionDTO> allRegions = await clsRegionLite.ReadRegionsFromFile();

                List<CityDTO> cities = await clsCityLite.ReadCitiesFromFile();

                List<DistrictDTO> csvData = await clsDistrictLite.ReadDistrictsFromFile();

                await clsDistrictLite.SaveDistrictsAsync(csvData);

                await clsRegionLite.SaveRegionsAsync(allRegions);

                await clsCityLite.SaveCitiesAsync(cities);
            }

            if (!clsTypeLite.IsTypesSaved())
            {
                List<TypeDTO> types = await clsType.GetAllTypes();

                await clsTypeLite.SaveTypesAsync(types);
            }

            if (!clsCategoryLite.IsCategoriesSaved())
            {
                List<CategoryDTO> Categories = await clsCategory.GetAllCategories();

                await clsCategoryLite.SaveCategoriesAsync(Categories);
            }
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

            Preferences.Default.Set("Mode", Mode);

        }
    }
}
