namespace DAL_Models

open System
open System.ComponentModel.DataAnnotations
open System.ComponentModel.DataAnnotations.Schema;

[<CLIMutable>]
type Catalog_Value = {
    [<Key>]
    Id: string
    
    IntegerValue: int
    StringValue: string
    
    [<ForeignKey("Catalog_Attribute")>]
    Attribute: Catalog_Attribute
    
}

and [<CLIMutable>]
    Catalog_Attribute = {
        [<Key>]
        Id: int
        AttributeName: string
        
        ValueId: int    
        Value: Catalog_Value
}