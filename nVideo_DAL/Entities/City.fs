namespace DAL_Models

open System
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type City = {
    [<Key>]
    Id: Guid
    Name: string
    OfficeLocation: string
}