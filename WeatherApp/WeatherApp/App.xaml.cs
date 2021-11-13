using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using WeatherApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("NTI5MTUwQDMxMzkyZTMzMmUzMEtYVjhRRFVKWm5HbEFZQ1NIdWRYeUVxWUtQZkJOb1lKVVovMW5wcnBsSUk9");

            InitializeComponent();
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            
            //await NavigationService.NavigateAsync($"/{nameof(WeatherAppMasterDetailPage)}/NavigationPage/{nameof(LoginPage)}");
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<WeatherPage, WeatherPageViewModel>();
            containerRegistry.RegisterForNavigation<CitiesPage, CitiesPageViewModel>();
            containerRegistry.RegisterForNavigation<CityDetailPage, CityDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<WeatherAppMasterDetailPage, WeatherAppMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterConfirmationPage, RegisterConfirmationPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
        }
    }
}
