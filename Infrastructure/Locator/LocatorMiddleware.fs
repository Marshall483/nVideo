namespace Location

open Microsoft.AspNetCore.Http
open Locator

type CitiesMiddleware(next: RequestDelegate) =

    member this.Next = next
      
    member this.InvokeAsync(context: HttpContext) =
        async{ 

            if not (context.Request.Cookies.ContainsKey("City")) then
                let! locate = LocatorService.GetCityAsync()
                context.Response.Cookies.Append("City", locate);

        } |> ignore

        next.Invoke(context)
        
