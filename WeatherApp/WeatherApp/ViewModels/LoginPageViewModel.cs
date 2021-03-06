using Prism.Commands;
using Prism.Navigation;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _password;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;

        public LoginPageViewModel(INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            Title = "Login";
            _navigationService = navigationService;
            _apiService = apiService;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter an email.", Languages.Accept);
                Password = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter a password.", Languages.Accept);
                Password = string.Empty;
                return;
            }

            string url = "https://weatherappcet58.azurewebsites.net/";

            string email = Email;

            string password = Password;

            Response response = await _apiService.CheckUserAPI(url, "api/Users/", email + "/" + password);

            var user = (bool)response.Result;

            if (!user)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Email or Passoword are incorrect!", Languages.Accept);
                return;
            }

            await NavigationService.NavigateAsync($"/{nameof(WeatherAppMasterDetailPage)}/NavigationPage/{nameof(CitiesPage)}");
        }

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }


    }
}
