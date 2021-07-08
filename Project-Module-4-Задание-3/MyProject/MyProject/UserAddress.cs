using System.ComponentModel.DataAnnotations;

namespace MyProject
{
    public class UserAddress
    {
        public UserAddress(int userId, string city, string address, string phoneNumber)
        {
            UserId = userId;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public int CountryCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }
        
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

    }
}
