namespace DAL_Models

open System.ComponentModel.DataAnnotations
open nVideo_DAL.Entities

[<CLIMutable>]
type UserProfile = {
    [<Key>]
    Id: int
    
    Name: string
    LastName: string
    Age: sbyte
    Phone: string
    City: City
    Address: string
    
    UserId: string
    User: User
    
    Avatar: byte[]
}

