using IpInfo;
using System.Net.Http;
using System.Threading.Tasks;

namespace nVideo.DATA.Services
{
    public class LocatorService
    {
        private readonly string token = "1432677e806667";
        public async Task<string> GetyCityAsync()
        {
            var client = new HttpClient();
            var api = new IpInfoApi(token, client);
            var response = await api.GetCurrentInformationAsync();

            return response.City;
        }
    }
}
