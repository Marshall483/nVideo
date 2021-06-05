namespace Location

open System.Net.Http;
open IpInfo;

module Locator = 

     let token = "1432677e806667";

     type LocatorService = 

        static member GetCityAsync() = 
            async{

                let! locationRespone = 
                    IpInfoApi(token, new HttpClient())
                        .GetCurrentInformationAsync() |> Async.AwaitTask

                return locationRespone.City
            }
        



