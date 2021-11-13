using Prism.Navigation;

namespace WeatherApp.ViewModels
{
    public class AboutPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AboutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }


    }
}
