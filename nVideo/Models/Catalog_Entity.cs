using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nVideo.Models;

namespace nVideo.Models
{
    public class Catalog_Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ushort Articul { get; set; }
        public ushort Price { get; set; }
        public string Short_Desc { get; set; }
        public string Long_Desc { get; set; }
        public byte Raiting { get; set; }
        public bool Awailable { get; set; }


        public virtual List<Image> Images { get; set; }
        public virtual List<Catalog_Attribute> Attributes { get; set; }
        public virtual List<Comment> Commentaries { get; set; }

        public int? CategoryId { get; set; }
        public Catalog_Category Category { get; set; }
    }
}
