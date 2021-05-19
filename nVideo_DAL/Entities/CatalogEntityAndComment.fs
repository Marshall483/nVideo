namespace DAL_Models

open System
open System.Collections.Generic
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Catalog_Entity = {
    
    [<Key>]
    Id: int
    
    Name: string
    Articul: string
    Price: uint
    Short_Desc: string
    Long_Desc: string
    Rating: byte
    Awailable: bool
    InStock: uint
    
    Images: ICollection<Catalog_Picture>
    Attributes: ICollection<Catalog_Attribute>
    Comments: ICollection<Catalog_Comment>
    
}

and [<CLIMutable>]
    Catalog_Comment = {
        [<Key>]
        Id: int
        
        Content: string
        Rating: uint
        
        EntityId: int
        Entity: Catalog_Entity
}