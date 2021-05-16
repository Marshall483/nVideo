module nVideo_DAL.Entities.Catalog_Value
open nVideo_DAL.Entities.Catalog_Attribute
open System.ComponentModel.DataAnnotations;
open System.ComponentModel.DataAnnotations.Schema;

type Catalog_Value = {
    [<Key>]
    Id: string
    
    IntegerValue: int
    StringValue: string
    
    [<ForeignKey("Catalog_Attribute")>]
    Attribute: Catalog_Attribute
}