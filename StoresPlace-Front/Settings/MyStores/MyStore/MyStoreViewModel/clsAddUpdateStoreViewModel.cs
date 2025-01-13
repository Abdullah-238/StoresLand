using StoresLand_API;
using StoresLand_API.Categories;
using StoresLand_API.RegionsServices;
using StoresLand_API.Stores;
using StoresLand_API.TypesServices;
using StoresPlace_Front.Sqlite;
using StoresPlace_Front.Sqlite.Regions;
using StoresPlace_Front.Strings;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Windows.Input;

namespace StoresPlace_Front.Settings.SettingsViewModel
{
    public class clsAddUpdateStoreViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        List<string> _regions { get; set; }
        public List<string> Regions
        {
            get => _regions;
            set
            {
                _regions = value;
                OnPropertyChanged();
            }
        }
        List<string> _cities { get; set; }
        public List<string> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }
        List<string> _districts { get; set; }
        public List<string> Districts
        {
            get => _districts;
            set
            {
                _districts = value;
                OnPropertyChanged();
            }
        }

        List<string> _categories { get; set; }
        public List<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        List<string> _types { get; set; }
        public List<string> Types
        {
            get => _types;
            set
            {
                _types = value;
                OnPropertyChanged();
            }
        }
        public StoreDTO Store { get; set; }


        private bool _isAccept = true;
        public bool IsAccept
        {
            get { return _isAccept; }
            set { _isAccept = value; }
        }

        private string? OldPath { get; set; }

        private string _selectedRegion;

        public string SelectedRegion
        {
            get => _selectedRegion;
            set
            {
                if (_selectedRegion != value)
                {
                    _selectedRegion = value;
                    OnPropertyChanged(nameof(SelectedRegion));
                    OnRegionSelected();
                }
            }
        }

        private string _selectedCity;

        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged(nameof(SelectedCity));
                    OnCitySelected();
                }
            }
        }


        private string _selectedDistrict;

        public string SelectedDistrict
        {
            get => _selectedDistrict;
            set
            {
                if (_selectedDistrict != value)
                {
                    _selectedDistrict = value;
                    OnPropertyChanged(nameof(SelectedDistrict));
                    // OnDistrictSelected();
                }
            }
        }


        private string _selectedCategory;

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(_selectedCategory));
                }
            }
        }

        private string _selectedType;

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                if (_selectedType != value)
                {
                    _selectedType = value;
                    OnPropertyChanged(nameof(_selectedType));
                }
            }
        }

        public ICommand TakePhotoCommand { get; set; }

        public ICommand SaveData { get; set; }

        public string ImagePath { get; set; }
        public clsAddUpdateStoreViewModel()
        {
            TakePhotoCommand = new Command(TakePhoto);
            SaveData = new Command(btCreate_Clicked);
        }
        public async void OnRegionSelected()
        {
            string selectedRegion = _selectedRegion;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Cities = await clsCityLite.GetAllCitiesByRegionNameAr(selectedRegion);
            }
            else
            {
                Cities = await clsCityLite.GetAllCitiesByRegionNameEn(selectedRegion);
            }

        }

        public async void OnCitySelected()
        {
            string selectedCity = _selectedCity;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameAr(selectedCity);
            }
            else
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameEn(selectedCity);
            }
        }


        public async void _Load()
        {
            IsBusy = true;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Regions = await clsRegionLite.GetAllRegionsByNameAr();

                Types = await clsTypeLite.GetAllTypesAr();

                Categories = await clsCategoryLite.GetAllCategoryAr();
            }
            else
            {

                Regions = await clsRegionLite.GetAllRegionsByNameEn();

                Categories = await clsCategoryLite.GetAllCategoryEn();

                Types = await clsTypeLite.GetAllTypesEn();
            }

            Store = new StoreDTO(null, "", "", null, "", "", null, null, null, null, null, null, "", null, null, null, null);
            Store.Rating = 5;
            Store.NumbersOfClick = 1;
            Store.NumberOfRates = 1;
            Store.Status = 2;
            Store.PeronID = clsGlobal.CurrentUser.PersonID;
            OldPath = null;

            IsBusy = false;

        }

        public async void _Load(int StoreID)
        {
            IsBusy = true;

            Store = await clsStore.GetStore(StoreID);

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Regions = await clsRegionLite.GetAllRegionsByNameAr();

                Types = await clsTypeLite.GetAllTypesAr();

                Categories = await clsCategoryLite.GetAllCategoryAr();


                SelectedRegion = await clsRegionLite.GetRegionNameArByCityID(Store.CityID);

                SelectedCity = await clsCityLite.GetCityNameArByCityID(Store.CityID);

                SelectedCategory = await clsCategoryLite.GetCategoryNameArByCategoryID(Store.CategoryID);

                SelectedType = await clsTypeLite.GetTypeNameArByTypeID(Store.TypeID);

                if (Store.DistrictsID != null)
                    SelectedDistrict = await clsDistrictLite.GetDistrictsNameArByDistrictsID(Store.DistrictsID);

            }
            else
            {
                Regions = await clsRegionLite.GetAllRegionsByNameEn();

                Categories = await clsCategoryLite.GetAllCategoryEn();

                Types = await clsTypeLite.GetAllTypesEn();


                SelectedRegion = await clsRegionLite.GetRegionNameEnByCityID(Store.CityID);

                SelectedCity = await clsCityLite.GetCityNameEnByCityID(Store.CityID);

                SelectedCategory = await clsCategoryLite.GetCategoryNameEnByCategoryID(Store.CategoryID);

                SelectedType = await clsTypeLite.GetTypeNameEnByTypeID(Store.TypeID);

                if (Store.DistrictsID != null)
                    SelectedDistrict = await clsDistrictLite.GetDistrictsNameEnByDistrictsID(Store.DistrictsID);

            }

            if (Store.Photo != null)
                OldPath = Store.Photo;

            IsBusy = false;

        }


        public static bool IsValidUri(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;
            Uri tmp;
            if (!Uri.TryCreate(uri, UriKind.Absolute, out tmp))
                return false;
            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }


        private async void btCreate_Clicked()
        {

            if (string.IsNullOrEmpty(Store.Name) || string.IsNullOrEmpty(Store.Address))
            {
                await AppShell.Current.DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);

                return;
            }

            if (!IsAccept)
            {
                await AppShell.Current.DisplayAlert(AppStrings.Terms_Conditions, AppStrings.Accept_Terms, AppStrings.Ok);
                return;
            }

            if (!IsValidUri(Store.Website) && !String.IsNullOrEmpty(Store.Website))
            {
                await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_Check_Webiste_link, AppStrings.Ok);
                return;
            }

            if (string.IsNullOrEmpty(Store.Website))
                Store.Website = null;

            if (SelectedCategory == null || SelectedCity == null || SelectedType == null || SelectedRegion == null)
            {
                await AppShell.Current.DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);

                return;
            }

            IsBusy = true;


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {

                Store.TypeID = await clsTypeLite.GetTypeIDByTypeNameAr(SelectedType);

                Store.CategoryID = await clsCategoryLite.GetCategoryIDByCategoryNameAr(SelectedCategory);

                if (SelectedDistrict != null)
                    Store.DistrictsID = await clsDistrictLite.GetDistrictsIDByDistrictNameAr(SelectedDistrict);
                else
                    Store.DistrictsID = null;

                Store.CityID = clsCityLite.GetCityIDByCityNameAr(SelectedCity);

            }
            else
            {
                Store.TypeID = await clsTypeLite.GetTypeIDByTypeNameEn(SelectedType);

                Store.CategoryID = await clsCategoryLite.GetCategoryIDByCategoryNameEn(SelectedCategory);

                if (SelectedDistrict != null)
                    Store.DistrictsID = await clsDistrictLite.GetDistrictsIDByDistrictNameEn(SelectedDistrict);
                else
                    Store.DistrictsID = null;

                Store.CityID = clsCityLite.GetCityIDByCityNameEn(SelectedCity);
            }

            _handleStoreImage();


            if (Store.StoreID != null)
            {
                if (await clsStore.UpdateStore(Store.StoreID, Store) != null)
                {
                    await AppShell.Current.DisplayAlert(AppStrings.Done, AppStrings.Data_Saved_Successfully, AppStrings.Ok);

                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Data_saved_failed, AppStrings.Ok);
                    return;

                }
            }
            else
            {
                if (await clsStore.AddStore(Store) != null)
                {

                    await AppShell.Current.DisplayAlert(AppStrings.Done, AppStrings.Data_Saved_Successfully, AppStrings.Ok);

                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Data_saved_failed, AppStrings.Ok);
                    return;

                }
            }

            IsBusy = false;

        }




        private async void TakePhoto()
        {


            FileResult photo = await MediaPicker.Default.PickPhotoAsync();

            if (MediaPicker.Default.IsCaptureSupported)
            {
                if (photo != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                    ImagePath = Path.Combine(FileSystem.CacheDirectory, fileName);

                    using Stream sourceStream = await photo.OpenReadAsync();

                    using FileStream localFileStream = File.OpenWrite(ImagePath);

                    await sourceStream.CopyToAsync(localFileStream);

                    string publicUrl = $"https://storesland.com/Images/{fileName}";

                    Store.Photo = publicUrl;

                }
            }

        }


        //private async void _handleStoreImage()
        //{
        //    if (Store.Photo != OldPath && !string.IsNullOrEmpty(OldPath))
        //    {
        //        try
        //        {
        //            string ftpServer = "ftp://win6057.site4now.net", ftpUsername = @"abdullah0-001", ftpPassword = @"Qq-12341234", remoteFolder = "storesplace/Images";



        //            using (WebClient client = new WebClient())
        //            {
        //                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
        //                client.UploadFile(new Uri(OldPath), WebRequestMethods.Ftp.DeleteFile); 
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionError(ex);  
        //        }
        //    }

        //    if (Store.Photo != null)
        //    {
        //        try
        //        {
        //            string ftpServer = "ftp://win6057.site4now.net", ftpUsername = @"abdullah0-001", ftpPassword = @"Qq-12341234", remoteFolder = "storesplace/Images";
        //            string fileName = Path.GetFileName(Store.Photo); 
        //            string fileUrl = $"{ftpServer}{remoteFolder}/{fileName}";

        //            using (WebClient client = new WebClient())
        //            {
        //                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

        //                await client.UploadFileTaskAsync(new Uri(fileUrl), WebRequestMethods.Ftp.UploadFile, Store.Photo);

        //                Console.WriteLine("New image uploaded successfully to FTP server.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionError(ex);  
        //        }
        //    }
        //}



        private async void _handleStoreImage()
        {
            if (Store.Photo != OldPath)
                if (OldPath != null)
                {


                    try
                    {
                        string ftpServer = "ftp://win6057.site4now.net", ftpUsername = @"abdullah0-001", ftpPassword = @"Qq-12341234", remoteFolder = "storesplace/Images";

                        Uri fileUri = new Uri($"{ftpServer}/{remoteFolder}/{Path.GetFileName(OldPath)}");

                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileUri);
                        request.Method = WebRequestMethods.Ftp.DeleteFile;
                        request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                        request.GetResponse();

                    }
                    catch (Exception ex)
                    {
                        clsUtil.WriteExceptionError(ex);
                    }
                }
            if (Store.Photo != null)
            {
                string ftpServer = "ftp://win6057.site4now.net", ftpUsername = @"abdullah0-001", ftpPassword = @"Qq-12341234", remoteFolder = "storesplace/Images";

                string fileName = Path.GetFileName(ImagePath);

                string fileUrl = $"{ftpServer}/{remoteFolder}/{fileName}";

                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                    try
                    {
                        client.UploadFileAsync(new Uri(fileUrl), WebRequestMethods.Ftp.UploadFile, ImagePath);
                    }
                    catch (Exception ex)
                    {
                        clsUtil.WriteExceptionError(ex);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}