namespace DAL_Models

open System
open System.Collections.Generic
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Catalog_Order = {
    
    [<Key>]
    Id: int
    
    CreatedTime: DateTime
    
    UserId: string
    User: User
    
    CustomerDataId: int
    CustomerData: UserProfile
    
    State: string
    
    Items: ICollection<Catalog_Entity>
}

