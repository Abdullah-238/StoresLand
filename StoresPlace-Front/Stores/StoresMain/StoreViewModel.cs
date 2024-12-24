
using StoresLand_API.CitiesServices;
using StoresLand_API.DistrictServices;
using StoresLand_API.RegionsServices;
using StoresLand_API.SavedStoresServices;
using StoresLand_API.Stores;
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

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                if (!clsRegionArDataLite.isRegionsArSaved())
                {
                    Regions = await clsRegion.GetAllRegionsByNameAr();

                    clsRegionArDataLite.SaveRegionsArAsync(Regions);
                }

                Regions = clsRegionArDataLite.LoadRegionsArAsync();

                Stores = await clsStore.GetStoresByCategoryNameAr(CategoryName, clsGlobal.TypeID);
            }
            else
            {
                if (!clsRegionEnDataLite.isRegionsEnSaved())
                {
                    Regions = await clsRegion.GetAllRegionsByNameEn();

                    clsRegionEnDataLite.SaveRegionsEnAsync(Regions);
                }

                Regions = clsRegionEnDataLite.LoadRegionsEnAsync();

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

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Cities = await clsCity.GetAllCitiesByRegionNameAr(selectedRegion);

                Stores = await clsStore.GetStoresByCategoryNameArAndRegionNameAr(_CategoryName, selectedRegion, clsGlobal.TypeID);
            }
            else
            {
                Cities = await clsCity.GetAllCitiesByRegionNameEn(selectedRegion);

                Stores = await clsStore.GetStoresByCategoryNameEnAndRegionNameEn(_CategoryName, selectedRegion, clsGlobal.TypeID);
            }

        }

        public async void OnCitySelected()
        {
            string selectedCity = _selectedCity;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Districts = await clsDistrict.GetDistrictsByCityNameAr(selectedCity); ;

                Stores = await clsStore.GetStoresByCategoryNameArAndCityNameAr(_CategoryName, selectedCity, clsGlobal.TypeID);
            }
            else
            {
                Districts = await clsDistrict.GetDistrictsByCityNameEn(selectedCity); ;

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
