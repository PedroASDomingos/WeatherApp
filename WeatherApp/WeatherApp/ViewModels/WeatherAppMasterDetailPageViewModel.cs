using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WeatherApp.Helpers;
using WeatherApp.ItemViewModels;
using WeatherApp.Models;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class WeatherAppMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public WeatherAppMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_person",
                    PageName = $"{nameof(AboutPage)}",
                    Title = "About",
                    IsLoginRequired = true
                },
                new Menu
                {
                    Icon = "ic_cloud_queue",
                    PageName = $"{nameof(CitiesPage)}",
                    Title = Languages.Cities,
                    IsLoginRequired = true
                },
                new Menu
                {
                    Icon = "ic_country",
                    PageName = $"{nameof(MapPage)}",
                    Title = "My location",
                    IsLoginRequired = true
                },
                 new Menu
                {
                    Icon = "ic_logout",
                    PageName = $"{nameof(MainPage)}",
                    Title = "Logout",
                    IsLoginRequired = true
                }

            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title,
                    IsLoginRequired = m.IsLoginRequired
                }).ToList());
        }
    }
}
