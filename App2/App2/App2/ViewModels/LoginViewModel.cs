
using System;
using System.Windows.Input;
using Android.Widget;
using Xamarin.Forms;
using XamarinExam.Model.Entities;
using XamarinExam.Model.Services;
using XamarinExam.Pages;

namespace XamarinExam.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {


        UserDatabase database = new UserDatabase();

       private User user = new User();

        public User User
        {
            get { return user; }
            set { user = value;OnPropertyChanged(); }
        }

        public LoginViewModel()
        {
           
        }

        public ICommand OnLoginClick
        {
            get
            {
                return new Command(
                    () =>
                    {
                        var user = database.GetUser(this.user.UserName);
                        if (user == null)
                        {
                            CurrentPage.DisplayAlert("Alert", "User not exists", "OK");
                            return;
                        }
                        
                        if (!((user.UserName == this.user.UserName) && (user.Password == this.user.Password)))
                            {
                                CurrentPage.DisplayAlert("Alert", "Incorrect Password or User Name please verify", "OK");

                                
                            }
                            // go to main page, without navigation
                            Application.Current.MainPage = new NavigationPage(new MainPage());
                        
                    });
            }
        }

        /// <summary>
        /// Obtiene el comando de ejecución al hacer click en el botón de registro de usuario.
        /// </summary>
        public ICommand OnRegisterClick
        {
            get
            {
                return new Command(
                    () =>
                    {
                        Application.Current.MainPage = new NavigationPage(new RegisterPage());
                    });
            }
        }
    }
}