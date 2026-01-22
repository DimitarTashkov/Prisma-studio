using Prisma_studio.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoStudio.Data.Models
{
    public class PhotoSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SessionDate { get; set; } // Дата на снимките

        [Required]
        public TimeSpan StartTime { get; set; } // Начален час (напр. 14:30)

        public bool IsConfirmed { get; set; } = false; // Статус на резервацията

        public string Notes { get; set; } // Допълнителни бележки от клиента

        // Връзка с Потребител
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        // Връзка с Услуга
        [Required]
        public int PhotoServiceId { get; set; }

        [ForeignKey(nameof(PhotoServiceId))]
        public virtual PhotoService PhotoService { get; set; }
    }
}