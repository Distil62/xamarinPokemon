using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ynovXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("uwp=54af2434-e75c-4f9c-9f3b-93133423e14e;" + "android=e6eca32b-db50-4789-8c97-5ca16f3b4d5a" + "ios=daddacee-e140-4a8d-bc3f-b5e293654ac5", typeof(Analytics));
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
