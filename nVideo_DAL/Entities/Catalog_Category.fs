namespace DAL_Models

open System.Collections.Generic
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Catalog_Category = {
    
    [<Key>]
    Id: int
    
    CategoryName: string
    
    Entities: ICollection<Catalog_Entity>
}
