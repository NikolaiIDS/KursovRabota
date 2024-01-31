using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Data.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime RegistrationDeadline { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Location { get; set; } = null!;

        [Required]
        public int MaxParticipants { get; set; }

        [Required]
        public bool IsFull { get; set; }

        [Required]
        public bool IsActive { get; set; }


        [Required]
        public CompetitionType CompetitionType { get; set; } = null!;


        [Required]
        public Subject Subject { get; set; } = null!;
    }

}
