using StoresLand_API.Categories;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace StoresPlace_Front.Categories
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value) 
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));  
                }
            }
        }

        List<string> _Categories { get; set; }

        public ICommand ChooseCategory { get; set; }

        public List<string> Categories
        {
            get => _Categories;
            set
            {
                _Categories = value;
                OnPropertyChanged();  
            }
        }

        public async void MoveToCategory(string Category)
        {
            IsBusy = true;

            await Task.Delay(10);

            if (Category != null)
            {
                //  pgStores stores = new pgStores();

                string CategoryName = Category.ToString();


                await AppShell.Current.GoToAsync($"Stores?categoryName={CategoryName}");

            }

            IsBusy = false;
        }
        
        public async void Load()
        {
            if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                Categories = await clsCategory.GetAllCategoryAvailableByNameAr(clsGlobal.TypeID);
            }
            else
            {
                Categories = await clsCategory.GetAllCategoryAvailableByNameEn(clsGlobal.TypeID);
            }
        }

       
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CategoriesViewModel()
        {
            ChooseCategory = new Command<string>(MoveToCategory);
        }

    }



}
