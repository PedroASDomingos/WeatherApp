using Prism.Commands;
using Prism.Navigation;
using System;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class RegisterConfirmationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _goToLoginCommand;

        public RegisterConfirmationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand GoToLoginCommand => _goToLoginCommand ?? (_goToLoginCommand = new DelegateCommand(GoToLogin));

        private async void GoToLogin()
        {
            await NavigationService.NavigateAsync($"/NavigationPage/{nameof(LoginPage)}");
        }
    }
}
