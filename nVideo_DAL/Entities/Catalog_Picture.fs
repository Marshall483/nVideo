namespace DAL_Models

open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Catalog_Picture = {
    
    [<Key>]
    Id: int  
    Patch: string
}

