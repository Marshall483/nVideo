namespace nVideo.Models

open Models
open System.Collections.Generic

type IndexViewModel = 
    {
        Carousel : ICollection<Product>
        Featured : ICollection<Product>
        Thumbnail : ICollection<Product>
        NewProducts : ICollection<Product>
    }

