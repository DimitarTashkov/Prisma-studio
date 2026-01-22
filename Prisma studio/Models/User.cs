using Prisma_studio.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Prisma_studio.Common.Constants.ValidationConstants.UserConstants;

namespace Prisma_studio.Models
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

        public HashSet<UserRole> UsersRoles { get; set; }
        = new HashSet<UserRole>();

        public virtual ICollection<PhotoSession> PhotoSessions { get; set; } = new HashSet<PhotoSession>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();


    }
}
