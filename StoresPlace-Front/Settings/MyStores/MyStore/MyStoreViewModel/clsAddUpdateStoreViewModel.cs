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
                Districts = await  clsDistrictLite.GetAllDistrictByCityNameAr(selectedCity); 
            }
            else
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameEn(selectedCity); 
            }
        }


        public async void _Load()
        {
            IsBusy = true;

            Task.Delay(10);

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                if (!clsRegionLite.IsRegionsSaved())
                {
                    List<RegionDTO> AllRegions = await clsRegion.GetAllRegions();

                    await clsRegionLite.SaveRegionsAsync(AllRegions);
                }

                Regions = await clsRegionLite.GetAllRegionsByNameAr();

                Types = await clsTypeLite.GetAllTypesAr();

                Categories = await clsCategoryLite.GetAllCategoryAr();
            }
            else
            {
                if (!clsRegionLite.IsRegionsSaved())
                {
                    List<RegionDTO> AllRegions = await clsRegion.GetAllRegions();

                    await clsRegionLite.SaveRegionsAsync(AllRegions);
                }

                Regions = await clsRegionLite.GetAllRegionsByNameEn();

                Categories = await clsCategoryLite.GetAllCategoryEn();

                Types = await clsTypeLite.GetAllTypesEn();
            }

            Store = new StoreDTO(null, "", "", null, "", "", null, null, null, null, null, null, "", null,null , null , null);
            Store.Rating = 5;
            Store.NumbersOfClick = 1;
            Store.NumberOfRates = 1;
            Store.Status = 2;
            Store.PeronID = clsGlobal.CurrentUser.PersonID;


            IsBusy = false;

        }

        public async void _Load(int StoreID)
        {
            IsBusy = true;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Regions = await clsRegionLite.GetAllRegionsByNameAr();

                Store = await clsStore.GetStore(StoreID);

                Types = await clsTypeLite.GetAllTypesAr();

                Categories = await clsCategoryLite.GetAllCategoryAr();



                SelectedRegion = await clsRegionLite.GetRegionNameArByDistrictsID(Store.DistrictsID);

                SelectedCity = await clsCityLite.GetCityNameArByDistrictsID(Store.DistrictsID);

                SelectedCategory = await  clsCategoryLite.GetCategoryNameArByCategoryID(Store.CategoryID);

                SelectedType = await clsTypeLite.GetTypeNameArByTypeID(Store.TypeID);

                SelectedDistrict = await clsDistrictLite.GetDistrictsNameArByDistrictsID(Store.DistrictsID);

            }
            else
            {
                Regions =await clsRegionLite.GetAllRegionsByNameEn();

                Store = await clsStore.GetStore(StoreID);

                Categories = await clsCategoryLite.GetAllCategoryEn();

                Types = await clsTypeLite.GetAllTypesEn();


                SelectedRegion = await clsRegionLite.GetRegionNameEnByDistrictsID(Store.DistrictsID);

                SelectedCity = await clsCityLite.GetCityNameEnByDistrictsID(Store.DistrictsID);
    
                SelectedCategory = await clsCategoryLite.GetCategoryNameEnByCategoryID(Store.CategoryID);

                SelectedType = await clsTypeLite.GetTypeNameEnByTypeID(Store.TypeID);
          
                SelectedDistrict = await clsDistrictLite.GetDistrictsNameArByDistrictsID(Store.DistrictsID);

            }

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
         
            if (string.IsNullOrEmpty(Store.Name)  || string.IsNullOrEmpty(Store.Address))
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
            }
            else
            {
                Store.TypeID = await clsTypeLite.GetTypeIDByTypeNameEn(SelectedType);

                Store.CategoryID = await clsCategoryLite.GetCategoryIDByCategoryNameEn(SelectedCategory);

                if (SelectedDistrict != null)
                    Store.DistrictsID = await clsDistrictLite.GetDistrictsIDByDistrictNameEn(SelectedDistrict);
                else
                    Store.DistrictsID = null;

               // Store.CityID = await clsCity.G
            }

            if (ImagePath != Store.Photo)
            UploadImageToFtpAsync();

            //UploadImageToFTP(Store.Photo);

            if (Store.StoreID != null )
            {
                if (await clsStore.UpdateStore(Store.StoreID, Store) != null)
                {
                    IsBusy = true;

                    await Task.Delay(10);

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
                    IsBusy = true;

                    await Task.Delay(10);

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

                    string publicUrl = $"http://storesland.com/Images/{fileName}";

                    Store.Photo = publicUrl;

                }
            }

        }

        private async void UploadImageToFtpAsync()
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
                    clsUtil.WriteExceptionError(ex.Message);
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