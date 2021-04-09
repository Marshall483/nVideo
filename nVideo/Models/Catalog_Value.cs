using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nVideo.Models
{
    public class Catalog_Value
    {
        [Key]
        public int Id { get; set; }
        public int? IntegerValue { get; set; }
        public string StringValue { get; set; }

        [ForeignKey("Catalog_Attribute")]
        public Catalog_Attribute Attribute { get; set; }
    }
}
