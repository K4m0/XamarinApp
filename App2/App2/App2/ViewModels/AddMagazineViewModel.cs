
using System.Collections.ObjectModel;
using System.Windows.Input;
using Android.Content.Res;
using Javax.Security.Auth;
using Org.Apache.Http.Client.Utils;
using Xamarin.Forms;
using XamarinExam.Model.Entities;
using XamarinExam.Model.Services;
using XamarinExam.Pages;

namespace XamarinExam.ViewModels
{
    public class AddMagazineViewModel : ViewModelBase
    {
        private RestService _client;

        private Magazine magazine;

        public Magazine Magazine
        {
            get { return magazine; }
            set { magazine = value; OnPropertyChanged(); }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public AddMagazineViewModel()
        {
            Magazine = new Magazine();
            _client = new RestService();
        }

        async void createMagazine()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (magazine.Name == null || Magazine.Publisher == null || Magazine.PublishDate == null || Magazine.Version == null)
            {
                await CurrentPage.DisplayAlert("Alert", "Check empty info", "OK");
                return;
            }

            await _client.SaveTodoItemAsync(Magazine, "Books");
            await CurrentPage.DisplayAlert("Alert", "Book added", "OK");
            IsBusy = false;
        }

        public ICommand OnAddMagazineClick
        {
            get
            {
                return new Command(
                    () =>
                    {
                        createMagazine();
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    });
            }
        }

        public ICommand OnCancelClick
        {
            get
            {
                return new Command(
                    () =>
                    {
                        Application.Current.MainPage = new NavigationPage(new MainPage());
                    });
            }
        }
    }
}