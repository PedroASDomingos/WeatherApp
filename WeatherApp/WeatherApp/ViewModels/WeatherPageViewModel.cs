using Prism.Navigation;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class WeatherPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<CityResponse> _cityResponses;
        public WeatherPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Weather Page";
            LoadWeatherAsync();
        }

        public List<CityResponse> Cities
        {
            get => _cityResponses;
            set => SetProperty(ref _cityResponses, value);
        }

        private async void LoadWeatherAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetListAsync<CityResponse>(url, "/data/2.5/box", "/city?bbox=12,32,15,37,10&appid=abfa1e579f20bd56faa2049d4c410206");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            Cities = (List<CityResponse>)response.Result;
        }
    }
}
