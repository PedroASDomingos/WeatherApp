using Prism.Navigation;

namespace WeatherApp.ViewModels
{
    public class ModifyUserPageViewModel : ViewModelBase
    {
        public ModifyUserPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "ModifyUser";
        }
    }
}
