using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedeiApp
{
    public partial class App : Application
    {
        public NavigationPage NavigationPage
        {
            get;
            set;
        }
        public App()
        {
            InitializeComponent();

            var menuPage = new MenuPage();
            NavigationPage = new NavigationPage(new MedeiAppPage());
            var rootPage = new RootPage();
            rootPage.Master = menuPage;
            rootPage.Detail = NavigationPage;
            MainPage = rootPage;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
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
