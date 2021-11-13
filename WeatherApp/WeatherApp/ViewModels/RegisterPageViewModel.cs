using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System.Net.Http;
using System.Net.Http.Headers;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private DelegateCommand _registerCommand;
        private string _password;
        private string _passwordConfirm;
        private readonly INavigationService _navigationService;

        public RegisterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Register";
            _navigationService = navigationService;
        }

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(RegisterUser));

        private async void RegisterUser()
        {
          
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter an email.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter a password.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Confirm))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You must enter a confirm password.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }

            if (Password != Confirm)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "password and confirmation password must be identical.", Languages.Accept);
                Password = string.Empty;
                Confirm = string.Empty;
                return;
            }
            var model = new RegisterResponse
            {
                Email = Email,
                Password = Password
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = new HttpClient();

            var response = await client.PostAsync("https://weatherappcet58.azurewebsites.net/api/Users/", httpContent);

            if (response != null)
            {
                await NavigationService.NavigateAsync($"/NavigationPage/{nameof(RegisterConfirmationPage)}");
            }
        }

        public string Email { get; set; }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string Confirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value);
        }
    }
}
