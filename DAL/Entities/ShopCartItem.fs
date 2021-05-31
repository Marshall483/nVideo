namespace DAL_Models

open System
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type ShopCartItem = {
    
    [<Key>]
    Id:Guid
    
    Entity: Catalog_Entity
    Quanity: uint
    UserName: string
    
    OrderId: int
    Order: Catalog_Order
    
}