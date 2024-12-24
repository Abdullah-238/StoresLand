
using StoresLand_API.AppSettingsServices;
using StoresLand_API.Persons;
using StoresPlace_Front;


public class clsGlobal
{



    public static Person CurrentUser;

    public static int? TypeID { get; set; }

    public async static void CheckInitialConnectivity(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess != NetworkAccess.Internet)
        {
            await AppShell.Current.GoToAsync("NoInternetConnection");
        }
    }

    public static async void CheckForUpdateAsync()
    {
        var currentVersion = AppInfo.VersionString;

        var latestVersion = await clsAppSettings.GetVersionStringAsync();

        if (currentVersion != latestVersion)
        {
            await AppShell.Current.GoToAsync("UpdatePage");
        }
    }

};
