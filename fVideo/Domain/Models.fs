namespace Models

open System
open System.Collections.Generic
open Microsoft.AspNetCore.Identity

[<CLIMutable>]
type Product = 
        {
            Id : Guid
            Name : string
            Articul : string
            Price : decimal
            ShortDescription : string
            Description : string
            Raiting : decimal
            Date : DateTime
            InStock : int
            IsAvailable : bool
        
            Image: ICollection<Image> 
            Attributes: ICollection<Attribute>
            Reviews : ICollection<Review>

            CategoryId : Nullable<Guid>
            Category : Category
        }
and [<CLIMutable>]
    Category = 
        {
            Id : Guid
            Name : string
            Products : List<Product>
        }
and [<CLIMutable>]
    Image = 
        {
            Id : Guid
            Patch : string
            ProductId : Nullable<Guid>
            Product : Product
        }
and [<CLIMutable>]
    Order = 
        {
            Id : Guid
            CreatedTime : DateTime  
            UserId : Nullable<Guid>
            User : User
            CustomerDataId : Nullable<Guid>
            CustomerData : UserProfile
            State : string
            IsSelfDelivery : bool
            CityId : Nullable<Guid>
            City : City
        }
and [<CLIMutable>]
    OrderItem  =
    {
        Id : Guid
        Product : Product
        Quanity : int
        OrderId : Nullable<Guid>
        Order : Order
    }
and [<CLIMutable>]
    Review = 
    {
        Id : Guid
        Content : string
        Raiting : decimal
        UserId : Nullable<Guid>
        User : User
        ProductId : Nullable<Guid>
        Product : Product
    }
and [<CLIMutable>]
    Attribute =
    {
        Id : Guid
        Name : string
        ProductId : Nullable<Guid>
        Product : Product
        ValueId : Nullable<Guid>
        Value : Value
    }
and [<CLIMutable>]
    Value =
    {
        Id : Guid
        Int : Nullable<int>
        String : string
        Attribute : Attribute
    }
and [<CLIMutable>]
    UserProfile = 
    {
        Id : Guid
        Name : string
        LastName : string
        Age : int
        Phone : string
        City : string
        Adress : string
        User : User
    }
and User() = 
    inherit IdentityUser()
        [<DefaultValue>]
        val mutable ProfileId : Nullable<Guid>
        [<DefaultValue>]
        val mutable Profile : UserProfile
and [<CLIMutable>]
City =
    {
        Id : Guid
        Name : string
        OfficeLocation : string
    }
 



