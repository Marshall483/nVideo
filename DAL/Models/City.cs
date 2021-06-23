using System;

namespace Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OfficeLocation { get; set; }
        public City(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
