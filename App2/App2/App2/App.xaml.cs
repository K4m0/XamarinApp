
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExam.Model.Services;
using XamarinExam.Pages;
using XamarinExam.ViewModels;

namespace XamarinExam
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
          
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
