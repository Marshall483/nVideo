namespace DAL_Models

open Microsoft.EntityFrameworkCore

type AppDBContext(options : DbContextOptions<AppDBContext>) = 
    inherit DbContext(options)
    
    [<DefaultValue>]
    val mutable Categories : DbSet<Catalog_Category>
    
    [<DefaultValue>]
    val mutable Entities : DbSet<Catalog_Entity>
    
    [<DefaultValue>]
    val mutable Attributes : DbSet<Catalog_Attribute>
    
    [<DefaultValue>]
    val mutable Values : DbSet<Catalog_Value>
    
    [<DefaultValue>]
    val mutable Pictures : DbSet<Catalog_Picture>
    
    [<DefaultValue>]
    val mutable Comments : DbSet<User>
    
    [<DefaultValue>]
    val mutable Profiles : DbSet<UserProfile>
    
    [<DefaultValue>]
    val mutable ShopCartItems : DbSet<ShopCartItem>
    
    [<DefaultValue>]
    val mutable Orders : DbSet<Catalog_Order>
    
    [<DefaultValue>]
    val mutable Cities : DbSet<City>
    
    member public self.Categories with get() = self.Categories
                                   and set value = self.Categories <- value
    
    member public self.Entities with get() = self.Entities
                                   and set value = self.Entities <- value
    
    member public self.Attributes with get() = self.Attributes
                                   and set value = self.Attributes <- value
    
    member public self.Values with get() = self.Values
                                   and set value = self.Values <- value
    
    member public self.Pictures with get() = self.Pictures
                                   and set value = self.Pictures <- value
    
    member public self.Comments with get() = self.Comments
                                   and set value = self.Comments <- value
    
    member public self.Profiles with get() = self.Profiles
                                   and set value = self.Profiles <- value
    
    member public self.ShopCartItems with get() = self.ShopCartItems
                                     and set value = self.ShopCartItems <- value
    
    member public self.Orders with get() = self.Orders
                                   and set value = self.Orders <- value
    
    member public self.Cities with get() = self.Cities
                                   and set value = self.Cities <- value                                                                                                                                                                                                                         