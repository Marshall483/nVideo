using IpInfo;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Locating
{
    public class Detector : IDetector
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
