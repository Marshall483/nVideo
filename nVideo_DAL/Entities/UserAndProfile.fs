namespace DAL_Models

open System.Collections.Generic
open System.ComponentModel.DataAnnotations
open Microsoft.AspNetCore.Identity


type User =
    inherit IdentityUser
        val Comments: ICollection<Catalog_Comment>
        val Profile: UserProfile
        //val State<Cart>: CartState
        
and [<CLIMutable>]
 UserProfile = {
    
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

        

