using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nVideo.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Line length exceeded")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Line length exceeded")]
        public string LastName { get; set; }

        [Range(1, 110, ErrorMessage = "Incorrect Age")]
        public sbyte Age { get; set; }
        [MaxLength(20, ErrorMessage = "Max length 20")]
        public string Phone { get; set; }
        [MaxLength(20, ErrorMessage = "Max length 20")]
        public string City { get; set; }
        public string Address { get; set; }


        [ForeignKey("AspNetUsers")]
        public User User { get; set; }
    }
}
