using System.ComponentModel.DataAnnotations;

namespace JSJMExoticCarsWebApp.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Funds { get; set; }
    }
}
