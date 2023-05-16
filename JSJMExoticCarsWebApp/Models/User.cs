using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSJMExoticCarsWebApp.Models
{
    [Table("UsersTable")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("user_name")]
        public string Name { get; set; }

        [Required]
        [Column("user_password")]
        public string Password { get; set; }

        [Required]
        [Column("user_funds")]
        public int Funds { get; set; }

        [Column("car_owner_id")]
        public List<Car> Cars { get; set; } = new List<Car>();

        [NotMapped]
        public string? AdminNotes { get; set; }
    }
}
