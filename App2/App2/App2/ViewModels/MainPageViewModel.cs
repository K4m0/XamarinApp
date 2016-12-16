
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Content.Res;
using Xamarin.Forms;
using XamarinExam.Model.Entities;
using XamarinExam.Model.Services;
using XamarinExam.Pages;

namespace XamarinExam.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private BookDatabase _databaseBook;
        private MagazineDatabase _databaseMagazine;

        private RestService _restService;

        private ObservableCollection<IMaterial> materials;
        public ObservableCollection<IMaterial> Materials
        {
            get { return materials; }
            set { materials = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TopFreeApp> topFreeApps;
        public ObservableCollection<TopFreeApp> TopFreeApps
        {
            get { return topFreeApps; }
            set { topFreeApps = value; OnPropertyChanged(); }
        }


        public Command RefreshCommand { get; set; }

        private string searchMaterial;
        public string SearchMaterial
        {
            get { return searchMaterial; }
            set
            {
                searchMaterial = value;
                OnPropertyChanged();
            }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value; OnPropertyChanged();

            }
        }

        public MainPageViewModel()
        {
            Materials = new ObservableCollection<IMaterial>();
            TopFreeApps = new ObservableCollection<TopFreeApp>();
            RefreshCommand = new Command(() => Load());
            _restService = new RestService();
            _databaseBook = new BookDatabase();
            _databaseMagazine = new MagazineDatabase();
            Load();
            IsBusy = false;
        }

        public async void Load()
        {
            var GetTopFreeApp = await _restService.RefreshDataAsyncApp();
            if (GetTopFreeApp != null)
            {
                foreach (var app in GetTopFreeApp)
                {
                   // _databaseBook.AddBook(book);
                    TopFreeApps.Add(app);
                }
            }
            // var GetBooks = await _restService.RefreshDataAsync<List<Book>>("Books");
            //var GetMagazines = await _restService.RefreshDataAsync<List<Magazine>>("Magazines");

            //Materials.Clear();

            //if (GetBooks.Data != null)
            //{
            //    foreach (var book in GetBooks.Data)
            //    {
            //        _databaseBook.AddBook(book);
            //        Materials.Add(book);
            //    }
            //}

            //if (GetMagazines.Data != null)
            //{
            //    foreach (var magazine in GetMagazines.Data)
            //    {
            //        _databaseMagazine.AddMagazine(magazine);
            //        Materials.Add(magazine);
            //    }
            //}

            IsBusy = false;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            TopFreeApp selecTopFreeApps = (TopFreeApp)e.SelectedItem;
            if (selecTopFreeApps == null)
                return;
           
            
        }

        public ICommand OnTextChanged
        {
            get
            {
                return new Command(
                    () =>
                    {

                        List<IMaterial> entities =
                            (from e in Materials where e.Name.Contains(searchMaterial) select e).ToList<IMaterial>();

                        if (entities != null && entities.Any())
                        {
                            Materials = new ObservableCollection<IMaterial>(entities);
                        }
                        

                    });
            }
        }

        public ICommand OnAddBook
        {
            get
            {
                return new Command(
                    () =>
                    {

                        Application.Current.MainPage = new NavigationPage(new AddBookPage());

                    });
            }
        }
        public ICommand OnAddMagazine
        {
            get
            {
                return new Command(
                    () =>
                    {

                        Application.Current.MainPage = new NavigationPage(new AddMagazinePage());

                    });
            }
        }

    }
}