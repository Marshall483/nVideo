namespace Models
{
    public class Picture
    {

        public int Id { get; set; }
        public string Patch { get; set; }

        public int? Catalog_EntityId { get; set; }
        public Catalog_Entity Entity { get; set; }

    }
}
