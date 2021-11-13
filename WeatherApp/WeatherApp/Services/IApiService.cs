using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

        Task<Response> GetUserAPI(string urlBase, string servicePrefix, string controller);

        Task<Response> CheckUserAPI(string urlBase, string servicePrefix, string controller);
    }
}
