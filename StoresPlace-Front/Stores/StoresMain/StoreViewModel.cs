using StoresLand_API.CitiesServices;
using StoresLand_API.DistrictServices;
using StoresLand_API.RegionsServices;
using StoresLand_API.SavedStoresServices;
using StoresLand_API.Stores;
using StoresPlace.Global;
using StoresPlace_Front.Sqlite;
using StoresPlace_Front.Sqlite.Regions;
using StoresPlace_Front.Strings;
using System.Collections.ObjectModel;
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
        ObservableCollection<StoreDetailsDTO> _stores { get; set; }
        public ObservableCollection<StoreDetailsDTO> Stores
        {
            get => _stores;
            set
            {
                _stores = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<StoreDetailsDTO> _Allstores { get; set; }
        public ObservableCollection<StoreDetailsDTO> AllStores
        {
            get => _Allstores;
            set
            {
                _Allstores = value;
                OnPropertyChanged();
            }
        }

        private int? PageNumber = 1;
       
        public ICommand LoadMoreCommand { get; set; }

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

        ObservableCollection<StoreDetailsDTO> _mySavedStore { get; set; }
        public ObservableCollection<StoreDetailsDTO> MySavedStores
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
            IsBusy = true;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                MySavedStores = await clsSavedStore.GetSavedStoreByPersonIDAr(clsGlobal.CurrentUser.PersonID, PageNumber);
            }
            else
                MySavedStores = await clsSavedStore.GetSavedStoreByPersonIDEn(clsGlobal.CurrentUser.PersonID, PageNumber);

            IsBusy = false;

        }

        public StoreViewModel()
        {
            SelectStore = new Command<int>(OnStoreSelected);

            MoveToSavedStoreCommand = new Command<int>(MoveToSavedStore);


            // LoadMoreCommand = new Command(LoadMoreStores);

        }

        public async void _Load(string CategoryName)
        {

            IsBusy = true;

            _CategoryName = CategoryName;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
               // Regions = await clsRegionLite.GetAllRegionsByNameAr();

                AllStores = await clsStore.GetStoresByCategoryNameAr(CategoryName, clsGlobal.TypeID, PageNumber);

                Stores = AllStores;
            }
            else
            {
              //  Regions = await clsRegionLite.GetAllRegionsByNameEn();

                AllStores = await clsStore.GetStoresByCategoryNameEn(CategoryName, clsGlobal.TypeID, PageNumber);

                Stores = AllStores;
            }

            IsBusy = false;
        }


        public async void _RefreshStores()
        {
            IsBusy = true;

            Stores = AllStores;

            IsBusy = false;

        }

        public async void LoadMoreStores()
        {
            IsBusy = true;

            PageNumber++;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                var NewStores = await clsStore.GetStoresByCategoryNameAr(_CategoryName, clsGlobal.TypeID, PageNumber);

                if (NewStores != null)
                {
                    foreach (var s in NewStores)
                    {
                        AllStores.Add(s);
                        Stores.Add(s);
                    }
                }
                else
                    MyTool.MyToast(AppStrings.No_other_stores);
            }
            else
            {
               var NewStores = await clsStore.GetStoresByCategoryNameEn(_CategoryName, clsGlobal.TypeID, PageNumber);

                if (NewStores != null)
                {
                  foreach(var s in NewStores)
                    {
                       AllStores.Add(s);
                        Stores.Add(s);
                    }
                }
                else
                    MyTool.MyToast(AppStrings.No_other_stores);
            }

            IsBusy = false;

        }


        public async void LoadMoreSavedStores()
        {
            IsBusy = true;

            PageNumber++;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                var NewStores = await clsSavedStore.GetSavedStoreByPersonIDAr(clsGlobal.CurrentUser.PersonID, PageNumber);

                if (NewStores != null)
                {
                    foreach (var s in NewStores)
                    {
                        MySavedStores.Add(s);
                    }
                }
                else
                    MyTool.MyToast(AppStrings.No_other_stores);
            }
            else
            {
                var NewStores = await clsSavedStore.GetSavedStoreByPersonIDEn(clsGlobal.CurrentUser.PersonID, PageNumber);

                if (NewStores != null)
                {
                    foreach (var s in NewStores)
                    {
                        MySavedStores.Add(s);
                    }
                }
                else
                    MyTool.MyToast(AppStrings.No_other_stores);
            }

            IsBusy = false;

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

            IsBusy = true;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Cities = await clsCityLite.GetAllCitiesByRegionNameAr(_selectedRegion);
            }
            else
            {
                Cities = await clsCityLite.GetAllCitiesByRegionNameEn(_selectedRegion);
            }

            var filteredStores = AllStores.Where(x => x.RegionName == _selectedRegion);

            if (filteredStores != null)
            {
                Stores = new ObservableCollection<StoreDetailsDTO>(filteredStores);
            }
            IsBusy = false;

        }

        public async void OnCitySelected()
        {
            IsBusy = true;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameAr(_selectedCity); ;

            }
            else
            {
                Districts = await clsDistrictLite.GetAllDistrictByCityNameEn(_selectedCity); ;
            }

            var filteredStores = AllStores.Where(x => x.CategoryName == _CategoryName && x.CityName == _selectedCity);

            if (filteredStores != null)
            {
                Stores = new ObservableCollection<StoreDetailsDTO>(filteredStores);
            }
            IsBusy = false;

        }

        public async void OnDistrictSelected()
        {
            IsBusy = true;

            var filteredStores = AllStores.Where(x => x.CategoryName == _CategoryName && x.DistrictsName == _selectedDistrict);

            if (filteredStores != null)
            {
                Stores = new ObservableCollection<StoreDetailsDTO>(filteredStores);
            }

            IsBusy = false;

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
