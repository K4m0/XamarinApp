
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
    public class RegisterViewModel : ViewModelBase
    {

        private User user = new User();

        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
        private UserDatabase _database = new UserDatabase();

        public RegisterViewModel()
        {
            
        }


        public ICommand OnCreateUserClick
        {
            get
            {
                return new Command(
                    () =>
                    {
                        if (!(user.Password == password))
                        {
                            CurrentPage.DisplayAlert("Alert", "Please verify your password", "OK");
                            return;
                        }

                        _database.AddUser(user.FullName,user.UserName, password);

                        CurrentPage.DisplayAlert("Alert", "User created", "OK");

                        Application.Current.MainPage = new NavigationPage(new LoginPage());

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
                        Application.Current.MainPage = new NavigationPage(new LoginPage());
                       
                    });
            }
        }
    }
}