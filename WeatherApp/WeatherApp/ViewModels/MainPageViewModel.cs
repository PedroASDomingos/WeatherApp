using Prism.Mvvm;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {

        public MainPageViewModel()
        {
            Onboardings = GetOnboarding();
        }

        public List<Onboarding> Onboardings { get; set; }

        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding {Heading = "Welcome to Weather APP", Caption = " "},
                new Onboarding { Heading = "Please Sign In", Caption = " " },
                new Onboarding { Heading = "Or register via the App or the website", Caption = "https://weatherappcet58.azurewebsites.net" },
            };
        }
    }
}



