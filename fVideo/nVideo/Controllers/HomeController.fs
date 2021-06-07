namespace nVideo.Controllers

open System
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Models
open nVideo.Models
open System.Linq
open Microsoft.EntityFrameworkCore
open Application
open DataLayer

type HomeController (context : AppDbContext) =
    inherit Controller()

    let products = context.Products.Include(fun x -> x.Image)

    member this.Index () =
        DbProduct.Initial context 
        let carousel = products.OrderByDescending(fun x -> x.Raiting).Take(10).ToList()
        let featured = products.OrderByDescending(fun x -> x.Raiting).Take(10).ToList()
        let newProducts = products.OrderByDescending(fun x -> x.Date).Take(10).ToList()
        let thumbnail = products.AsParallel().Take(3).ToList()

        
        let model = {
            Carousel = carousel
            Featured = featured
            Thumbnail = thumbnail
            NewProducts = newProducts
        }
        this.View(model)
    member this.Privacy () =
        this.View()

    

    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error () =
        let reqId = 
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })
