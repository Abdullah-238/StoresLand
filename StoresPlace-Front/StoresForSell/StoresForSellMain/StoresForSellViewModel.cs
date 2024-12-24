using StoresLand_API.StoresForSaleServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoresPlace_Front.StoresForSell.StoresForSell
{
    public class StoresForSellViewModel : INotifyPropertyChanged
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
        public ICommand SelectStore { get; set; }
        public StoresForSellViewModel()
        {
            SelectStore = new Command<int>(OnStoreSelected);
        }
        List<StoresForSaleDetailsDTO> _stores { get; set; }
        public List<StoresForSaleDetailsDTO> Stores
        {
            get => _stores;
            set
            {
                _stores = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void _Load()
        {

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Stores = await clsStoresForeSaleService.GetAllStoresForSaleAr();
            }
            else
            {
                Stores = await clsStoresForeSaleService.GetAllStoresForSaleEn();
            }
        }
        private async void OnStoreSelected(int StoreID)
        {
            IsBusy = true;

            await Task.Delay(1);

            if (StoreID != null)
            {
                await Shell.Current.GoToAsync($"pgStoreForSellPage?storeID={StoreID}");
            }

            IsBusy = false;
        }

    }
}
