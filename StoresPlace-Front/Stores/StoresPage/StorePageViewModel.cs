using StoresLand_API.CouponsServices;
using StoresLand_API.Offers;
using StoresLand_API.Rates;
using StoresLand_API.SavedStoresServices;
using StoresLand_API.Stores;
using StoresPlace.Global;
using StoresPlace_Front.Strings;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace StoresPlace_Front.Stores.StoresPage
{
    public class StorePageViewModel : INotifyPropertyChanged
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

        StoreDetailsDTO _store { get; set; }

        List<string> _coupon;

        public List<string> Coupons
        {
            get => _coupon;
            set
            {
                _coupon = value;
                OnPropertyChanged();
            }
        }

        public StoreDetailsDTO Store
        {
            get => _store;
            set
            {
                _store = value;
                OnPropertyChanged();
            }
        }

        List<string> _offers;

        public List<string> Offers
        {
            get => _offers;
            set
            {
                _offers = value;
                OnPropertyChanged();
            }
        }

        string _isSaved;

        public string IsSaved
        {
            get => _isSaved;
            set
            {
                _isSaved = value;
                OnPropertyChanged();
            }
        }

        string _isRated;

        public string IsRated
        {
            get => _isRated;
            set
            {
                _isRated = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddToSavedStores { get; set; }

        public ICommand OpenUrl { get; set; }

        public ICommand Rate { get; set; }

        public StorePageViewModel()
        {
            OpenUrl = new Command<string>(OpenUri);

            AddToSavedStores = new Command<int>(SaveStore);

            Rate = new Command<int?>(RateStore);

            _isSaved = AppStrings.Save;

            _isRated = AppStrings.Rate_store;
        }

        public async void Load(int StoreID)
        {
            Offers = await clsOffers.GetAllOfferByStoreID(StoreID);

            Coupons = await clsCoupon.GetAllCouponsByStoreID(StoreID);

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
                Store = await clsStore.FindStoreAr(StoreID);
            else
                Store = await clsStore.FindStoreEn(StoreID);

            if (clsGlobal.CurrentUser != null)
            {
                if (!await clsSavedStore.IsSavedStoreExistsByStoreAndPerson(StoreID, clsGlobal.CurrentUser.PersonID))
                {
                    IsSaved = AppStrings.Save_Store;
                }
                else
                    IsSaved = AppStrings.Remove_store;



                if (!await clsRate.IsRateExistsByStoreAndPerson(StoreID, clsGlobal.CurrentUser.PersonID))
                {
                    IsRated = AppStrings.Rate_store;
                }
                else
                    IsRated = AppStrings.Update_Rate;
            }

        }

        private async void SaveStore(int StoreID)
        {
            if (clsGlobal.CurrentUser == null)
            {
                await Shell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
                return;
            }

            if (await clsSavedStore.IsSavedStoreExistsByStoreAndPerson(StoreID, clsGlobal.CurrentUser.PersonID))
            {
                if (await clsSavedStore.DeleteSavedStoreByStoreID(StoreID, clsGlobal.CurrentUser.PersonID))
                {
                    IsSaved = AppStrings.Save_Store;

                    MyTool.MyToast(AppStrings.The_store_has_been_added_successfully);
                }
                else
                {
                    MyTool.MyToast(AppStrings.The_store_was_not_added_successfully);
                }
            }
            else
            {
                SavedStoreDTO savedStore = new SavedStoreDTO(null, StoreID, clsGlobal.CurrentUser.PersonID);

                if (clsSavedStore.AddSavedStore(savedStore) != null)
                {
                    MyTool.MyToast(AppStrings.The_store_has_been_remove_successfully);

                    IsSaved = AppStrings.Remove_store;

                }
                else
                {
                    MyTool.MyToast(AppStrings.The_store_was_not_remove_successfully);
                }
            }
        }

        private async void RateStore(int? StoreID)
        {
            if (clsGlobal.CurrentUser == null)
            {
                await Shell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
                return;
            }

            await Shell.Current.GoToAsync($"AddNewRate?storeID={StoreID}");
        }

        public async void OpenUri(string UriString)
        {
            try
            {
                Uri uri = new Uri(UriString);

                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert(AppStrings.Error, AppStrings.Error_opening_the_website, AppStrings.Ok);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
