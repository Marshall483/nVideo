using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Models
{
    public class Catalog_Value
    {
        [Key]
        [ForeignKey("Catalog_Attribute")]
        public int Id { get; set; }
        public int? IntegerValue { get; set; }
        public string StringValue { get; set; }
        public bool? BoolValue { get; set; }

        public Catalog_Attribute Attribute { get; set; }
    }
}
