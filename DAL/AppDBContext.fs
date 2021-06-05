namespace DAL

open Microsoft.EntityFrameworkCore
open DAL_Models

type AppDBContext(options : DbContextOptions<AppDBContext>) = 
    inherit DbContext(options)
    
    [<DefaultValue>]
    val mutable _Categories : DbSet<Catalog_Category>
    
    [<DefaultValue>]
    val mutable _Entities : DbSet<Catalog_Entity>
    
    [<DefaultValue>]
    val mutable _Attributes : DbSet<Catalog_Attribute>
    
    [<DefaultValue>]
    val mutable _Values : DbSet<Catalog_Value>
    
    [<DefaultValue>]
    val mutable _Pictures : DbSet<Catalog_Picture>
    
    [<DefaultValue>]
    val mutable _Comments : DbSet<User>
    
    [<DefaultValue>]
    val mutable _Profiles : DbSet<UserProfile>
    
    [<DefaultValue>]
    val mutable _ShopCartItems : DbSet<ShopCartItem>
    
    [<DefaultValue>]
    val mutable _Orders : DbSet<Catalog_Order>
    
    [<DefaultValue>]
    val mutable _Cities : DbSet<City>
    
    member public self.Categories with get() = self._Categories
                                   and set value = self._Categories <- value
    
    member public self.Entities with get() = self._Entities
                                   and set value = self._Entities <- value
    
    member public self.Attributes with get() = self._Attributes
                                   and set value = self._Attributes <- value
    
    member public self.Values with get() = self._Values
                                   and set value = self._Values <- value
    
    member public self.Pictures with get() = self._Pictures
                                   and set value = self._Pictures <- value
    
    member public self.Comments with get() = self._Comments
                                   and set value = self._Comments <- value
    
    member public self.Profiles with get() = self._Profiles
                                   and set value = self._Profiles <- value
    
    member public self.ShopCartItems with get() = self._ShopCartItems
                                        and set value = self._ShopCartItems <- value
    
    member public self.Orders with get() = self._Orders
                                   and set value = self._Orders <- value
    
    member public self.Cities with get() = self._Cities
                                   and set value = self._Cities <- value                                                                                                                                                                                                                         