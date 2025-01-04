using StoresPlace_Front.Settings.SettingsViewModel;
using StoresPlace_Front.Strings;
using System.Globalization;
using System.Net;

namespace StoresPlace_Front.Settings.MyStores;

[QueryProperty("StoreID", "storeID")]

public partial class pgAddNewStore : ContentPage
{
    public int StoreID { get; set; }


    clsAddUpdateStoreViewModel storeViewModel = new clsAddUpdateStoreViewModel();
   

    public pgAddNewStore()
    {
        InitializeComponent();   
    }



    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (StoreID > 0)
        {
            storeViewModel._Load(StoreID);
        }
        else
        {
            storeViewModel._Load();
        }


        this.BindingContext = storeViewModel;
    }



    private async void Button_Clicked(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync();

        if (MediaPicker.Default.IsCaptureSupported)
        {

            if (photo != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                storeViewModel.ImagePath = Path.Combine(FileSystem.CacheDirectory, fileName);

                using Stream sourceStream = await photo.OpenReadAsync();

                using FileStream localFileStream = File.OpenWrite(storeViewModel.ImagePath);

                await sourceStream.CopyToAsync(localFileStream);

                string publicUrl = $"http://storesland.com/Images/{fileName}";

                storeViewModel.Store.Photo = publicUrl;

                imgCustomerImage.Source = storeViewModel.ImagePath;


            }
        }
    }
}
