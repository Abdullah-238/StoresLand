using StoresLand_API.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoresPlace_Front.Settings.SettingsViewModel
{
    public class clsMyStoreViewModel : INotifyPropertyChanged
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
        List<StoreDetailsDTO> _myStores { get; set; }

        public List<StoreDetailsDTO> MyStores
        {
            get => _myStores;
            set
            {
                _myStores = value;
                OnPropertyChanged();
            }
        }

      

        public ICommand MoveToStoreCommand { get; set; }



        public clsMyStoreViewModel() 
        {
            MoveToStoreCommand = new Command<int>(MoveToStore);



        }
        public async void Load()
        {

            if (clsGlobal.CurrentUser.PersonID == null)
                return;

            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                MyStores = await clsStore.GetAllStoresInDetailsByPersonIDAr(clsGlobal.CurrentUser.PersonID);
            }
            else
                MyStores = await clsStore.GetAllStoresInDetailsByPersonIDEn(clsGlobal.CurrentUser.PersonID);

        }


        async void MoveToStore(int StoreID)
        {
            IsBusy = true;

            if (StoreID != null)
            {
                await AppShell.Current.GoToAsync($"MyStorePage?storeID={StoreID}");
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
