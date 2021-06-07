namespace Validators

open Validators.Abstractions
open Microsoft.AspNetCore.Http
open System.Text
open System

type ImageValidator() = 
    


    member here.CheckExtention extention = 
        match extention with 
        | ".png" -> true
        | ".jpg" -> true
        | ".jpeg" -> true
        | _ -> false

    member here.ExtractExtension fileName:string = 
        fileName.Substring(
            fileName.LastIndexOf('.'),
            fileName.Length - fileName.LastIndexOf('.'))
                .ToLower();