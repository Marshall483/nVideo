using IpInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace nVideo.DATA.Services
{
    public class LocatorService
    {
        private readonly static string token = "1432677e806667";
        public static async Task<string> GetyCityAsync()
        {
            var client = new HttpClient();
            var api = new IpInfoApi(token, client);
            var response = await api.GetCurrentInformationAsync();

            return response.City;
        }
    }
}
