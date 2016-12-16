
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
    public class AddBookViewModel : ViewModelBase
    {
        private RestService _client;

        private Book book;

        public Book Book
        {
            get { return book; }
            set { book = value; OnPropertyChanged(); }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public AddBookViewModel()
        {
            Book = new Book();
            _client = new RestService();
        }

        async void createBook()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            if (book.Name == null || book.Publisher == null || book.PublishDate == null || book.Author == null)
            {
                await CurrentPage.DisplayAlert("Alert", "Check empty info", "OK");
                return;
            }

            await _client.SaveTodoItemAsync(Book, "Books");
            await CurrentPage.DisplayAlert("Alert", "Book added", "OK");
            IsBusy = false;
        }

        public ICommand OnAddBookClick
        {
            get
            {
                return new Command(
                    () =>
                    {
                        createBook();
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