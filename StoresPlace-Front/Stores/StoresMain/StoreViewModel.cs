using StoresLand_API.CitiesServices;
using StoresLand_API.DistrictServices;
using StoresLand_API.RegionsServices;
using StoresLand_API.SavedStoresServices;
using StoresLand_API.Stores;
using StoresPlace_Front.Sqlite;
using StoresPlace_Front.Sqlite.Regions;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace StoresPlace_Front.Stores.StoresMain
{

    public class StoreViewModel : INotifyPropertyChanged
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
        List<StoreDetailsDTO> _stores { get; set; }
        public List<StoreDetailsDTO> Stores
        {
            get => _stores;
            set
            {
                _stores = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectStore { get; set; }

        public ICommand MoveToSavedStoreCommand { get; set; }

        string _CategoryName;

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
                    OnDistrictSelected();
                }
            }
        }

        List<StoreDetailsDTO> _mySavedStore { get; set; }
        public List<StoreDetailsDTO> MySavedStores
        {
            get => _mySavedStore;
            set
            {
                _mySavedStore = value;
                OnPropertyChanged();
            }
        }

        public async void LoadSavedStores()
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                MySavedStores = await clsSavedStore.GetSavedStoreByPersonIDAr(clsGlobal.CurrentUser.PersonID);
            }
            else
                MySavedStores = await clsSavedStore.GetSavedStoreByPersonIDEn(clsGlobal.CurrentUser.PersonID);

        }

        public StoreViewModel()
        {
            SelectStore = new Command<int>(OnStoreSelected);

            MoveToSavedStoreCommand = new Command<int>(MoveToSavedStore);
        }

        public async void _Load(string CategoryName)
        {

            _CategoryName = CategoryName;

            //if (!clsRegionLite.IsRegionsSaved())
            //{
            //    List<RegionDTO> AllRegions = await clsRegion.GetAllRegions();

            //    await clsRegionLite.SaveRegionsAsync(AllRegions);
            //}


            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Regions = await clsRegionLite.GetAllRegionsByNameAr();

                Stores = await clsStore.GetStoresByCategoryNameAr(CategoryName, clsGlobal.TypeID);
            }
            else
            {
                Regions = await clsRegionLite.GetAllRegionsByNameEn();

                Stores = await clsStore.GetStoresByCategoryNameEn(CategoryName, clsGlobal.TypeID);
            }
        }

        private async void OnStoreSelected(int StoreID)
        {
            IsBusy = true;

            if (StoreID != null)
            {
                await Shell.Current.GoToAsync($"StorePage?storeID={StoreID}");
            }

            IsBusy = false;
        }
        async void MoveToSavedStore(int StoreID)
        {
            IsBusy = true;

            if (StoreID != null)
            {
                await Shell.Current.GoToAsync($"SavedStorePage?storeID={StoreID}");
            }
            IsBusy = false;

        }

        public async void OnRegionSelected()
        {
            string selectedRegion = _selectedRegion;

            //if (!clsCityLite.IsCitiesSaved())
            //{
            //    var cities = await clsCity.GetAllCities();

            //     clsCityLite.SaveCities(cities);
            //}

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Cities = await clsCityLite.GetAllCitiesByRegionNameAr(selectedRegion);

                Stores = await clsStore.GetStoresByCategoryNameArAndRegionNameAr(_CategoryName, selectedRegion, clsGlobal.TypeID);
            }
            else
            {
                Cities = await clsCityLite.GetAllCitiesByRegionNameEn(selectedRegion);

                Stores = await clsStore.GetStoresByCategoryNameEnAndRegionNameEn(_CategoryName, selectedRegion, clsGlobal.TypeID);
            }

        }

        public async void OnCitySelected()
        {
            string selectedCity = _selectedCity;

            //if (!clsDistrictLite.IsDistrictsSaved())
            //{
            //    var districts = await clsDistrict.GetAllDistrictsAsync();

            //     clsDistrictLite.SaveDistricts(districts);
            //}

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameAr(selectedCity); ;

                Stores = await clsStore.GetStoresByCategoryNameArAndCityNameAr(_CategoryName, selectedCity, clsGlobal.TypeID);
            }
            else
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameEn(selectedCity); ;

                Stores = await clsStore.GetStoresByCategoryNameEnAndCityNameEn(_CategoryName, selectedCity, clsGlobal.TypeID);
            }
        }

        public async void OnDistrictSelected()
        {
            string selectedCity = _selectedDistrict;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Stores = await clsStore.GetStoresByCategoryNameArAndDistrictsNameAr(_CategoryName, selectedCity, clsGlobal.TypeID);
            }
            else
            {
                Stores = await clsStore.GetStoresByCategoryNameArAndDistrictsNameAr(_CategoryName, selectedCity, clsGlobal.TypeID);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
