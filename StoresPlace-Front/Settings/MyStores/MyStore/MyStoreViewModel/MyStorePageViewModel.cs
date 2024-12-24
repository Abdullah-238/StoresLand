using StoresLand_API.CouponsServices;
using StoresLand_API.Offers;
using StoresLand_API.SavedStoresServices;
using StoresLand_API.Stores;
using StoresPlace.Global;
using StoresPlace_Front.Strings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoresPlace_Front.Settings.MyStores.MyStore.MyStoreViewModel
{
    public class MyStorePageViewModel : INotifyPropertyChanged
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

        private int ?_StoreID { get; set; } 

        StoreDetailsDTO _store { get; set; }

        ObservableCollection<CouponDTO> _coupon;

        public ObservableCollection<CouponDTO> Coupons
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

        ObservableCollection<OfferDTO> _offers;

        public ObservableCollection<OfferDTO> Offers
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


        public ICommand DeleteOfferCommand { get; set; }

        public ICommand UpdateOfferCommand { get; set; }

        public ICommand DeleteCouponCommand { get; set; }

        public ICommand UpdateCouponCommand { get; set; }

        public ICommand OpenUrl { get; set; }

        public MyStorePageViewModel()
        {
            OpenUrl = new Command<string>(OpenUri);

            DeleteOfferCommand = new Command<int?>(DeleteOffer);

            UpdateOfferCommand = new Command<OfferDTO>(UpdateOffer);

            DeleteCouponCommand = new Command<int?>(DeleteCoupon);

            UpdateCouponCommand = new Command<CouponDTO>(UpdateCoupon);

            _isSaved = AppStrings.Save;
        }

        public async void Load(int StoreID)
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
                Store = await clsStore.FindStoreAr(StoreID);
            else
                Store = await clsStore.FindStoreEn(StoreID);


            Offers = await clsOffers.GetAllOfferByStore(StoreID);

            Coupons = await clsCoupon.GetCouponsByStoreID(StoreID);

            if (clsGlobal.CurrentUser != null)
            {
                if (!await clsSavedStore.IsSavedStoreExistsByStoreAndPerson(StoreID, clsGlobal.CurrentUser.PersonID))
                {
                    IsSaved = AppStrings.Save_Store;
                }
                else
                    IsSaved = AppStrings.Remove_store;
            }


            _StoreID = StoreID;
        }


        public async void LoadCoupon()
        {
            var coupons = await clsCoupon.GetCouponsByStoreID(_StoreID);

            Coupons = new ObservableCollection<CouponDTO>(coupons);
        }

        public  async void LoadOffer()
        {
            var offers = await clsOffers.GetAllOfferByStore(_StoreID);

            Offers = new ObservableCollection<OfferDTO>(offers);
        }

        private async void DeleteOffer(int? OfferID)
        {
            if (clsGlobal.CurrentUser == null)
            {
                await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
                return;
            }

            IsBusy = true;

            bool isAccepted = await AppShell.Current.DisplayAlert(AppStrings.Warining, AppStrings.Are_you_sure_you_want_to_delete_your_offer, AppStrings.Yes, AppStrings.No);

            if (isAccepted)
            {

                if ( await clsOffers.DeleteOffer(OfferID))
                {
                    MyTool.MyToast(AppStrings.Offer_deleted_Succefully);

                    LoadOffer();

                }
                else
                    MyTool.MyToast(AppStrings.Offer_deleted_failed);
            }

            IsBusy = false;
        }

        private async void UpdateOffer(OfferDTO offer)
        {
            if (clsGlobal.CurrentUser == null)
            {
                await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
                return;
            }

            int StoreID = offer.StoreID.Value;
            int OfferID = offer.OfferID.Value;


            await Shell.Current.GoToAsync($"AddNewOffer?storeID={StoreID}&offerID={OfferID}");
        }

        private async void DeleteCoupon(int? couponID)
        {
            if (clsGlobal.CurrentUser == null)
            {
                await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
                return;
            }


            IsBusy = true; 

            bool isAccepted = await AppShell.Current.DisplayAlert(AppStrings.Warining, AppStrings.Are_you_sure_you_want_to_delete_your_coupon, AppStrings.Yes, AppStrings.No);

            if (isAccepted)
            {

                if (await clsCoupon.DeleteCoupon(couponID))
                {
                    MyTool.MyToast(AppStrings.coupon_deleted_Succefully);

                    LoadCoupon();

                }
                else
                    MyTool.MyToast(AppStrings.Coupon_delete_failed);
            }

            IsBusy = false;

        }

        private async void UpdateCoupon(CouponDTO coupon)
        {
            if (clsGlobal.CurrentUser == null)
            {
                await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
                return;
            }



            int StoreID = coupon.StoreID.Value;
            int CouponID = coupon.CouponID.Value;

            await Shell.Current.GoToAsync($"AddNewCoupon?storeID={StoreID}&couponID={CouponID}");

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
                await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Error_opening_the_website, AppStrings.Ok);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }



}
