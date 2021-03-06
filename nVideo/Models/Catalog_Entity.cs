﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NpgsqlTypes;
using nVideo.Models;

namespace nVideo.Models
{
    public class Catalog_Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Articul { get; set; }
        public uint Price { get; set; }
        public string Short_Desc { get; set; }
        public string Long_Desc { get; set; }
        public byte Raiting { get; set; }
        public bool Awailable { get; set; }
        public ushort InStock { get; set; }


        public virtual List<Picture> Images { get; set; }
        public virtual List<Catalog_Attribute> Attributes { get; set; }
        
        public virtual List<Comment> Comments { get; set; }

        
        public int? CategoryId { get; set; }
        public Catalog_Category Category { get; set; }
        
        
        public int? OrderId { get; set; }
        public Catalog_Order Order { get; set; }

        public NpgsqlTsVector SearchVector { get; set; }

    }
}
