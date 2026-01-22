using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HotelOazis.Common.Constants.ValidationConstants.UserConstants;

namespace HotelOazis.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        [MaxLength(NameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; } = null!;
        public int? Age { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string AvatarUrl { get; set; } = null!;
        public virtual HashSet<Reservation> Reservations { get; set; }
        = new HashSet<Reservation>();
        public virtual HashSet<Review> Reviews { get; set; }
        = new HashSet<Review>();
        public HashSet<UserRole> UsersRoles { get; set; }
        = new HashSet<UserRole>();

    }
}
