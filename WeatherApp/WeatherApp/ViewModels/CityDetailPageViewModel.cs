﻿using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{

    public class CityDetailPageViewModel : ViewModelBase
    {
        private List<DaysResponse> _myDays;
        private ObservableCollection<DaysResponse> _days;
        public string Image { get; set; }
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private CityResponse _city;

        public CityDetailPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            
        }

        public string CityKey { get; set; }
        public CityResponse City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public ObservableCollection<DaysResponse> Days
        {
            get => _days;
            set => SetProperty(ref _days, value);
        }



        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("city"))
            {
                
                City = parameters.GetValue<CityResponse>("city");
                Title = City.EnglishName;

                //LoadDays();
            }
        }

        private async void LoadDays()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.ConnectionError, Languages.Accept);
                });
                return;
            }

            string url = "api.openweathermap.org";

            Response response = await _apiService.GetListAsync<DaysResponse>(url, "/data/2.5/weather?q=", Title + "&appid=16324fda64ac2960cb0f8e283ae039d1");


            if (!response.IsSuccess)
            {
                return;
            }
            _myDays = (List<DaysResponse>)response.Result;

            Days = new ObservableCollection<DaysResponse>(_myDays);

        }
    }
}
