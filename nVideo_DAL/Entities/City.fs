module nVideo_DAL.Entities.City
open System



type City (nameIn : string, OfficeLocationIn : string) = 
    let mutable Id: Guid = Guid.NewGuid()
    let mutable Name = nameIn
    let mutable OfficeLocation = OfficeLocationIn
    

