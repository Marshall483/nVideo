using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nVideo.Models
{
    public class UserProfile
    {
        public int Id { get; set; }


        [RegularExpression(@"[A-Za-zА-Яа-я]", ErrorMessage = "Name must contain only letters")]
        public string Name { get; set; }
        [RegularExpression(@"[A-Za-zА-Яа-я]", ErrorMessage = "Name must contain only letters")]
        public string LastName { get; set; }

        [Range(1, 110, ErrorMessage = "Incoffect Age")]
        public sbyte Age { get; set; }
        [Phone]
        public string Phone { get; set; }
        [MaxLength(20, ErrorMessage = "Max length 20")]
        public string City { get; set; }
        public string Address { get; set; }


        [ForeignKey("AspNetUsers")]
        public User User { get; set; }
    }
}
