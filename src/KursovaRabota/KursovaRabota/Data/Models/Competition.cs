using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Data.Models
{
    public class Competition
    {
        [Key]
        public Guid Id { get; set; }

        
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; } = null!;

        public int CurrentParticipants { get; set; }

        public DateTime RegistrationDeadline { get; set; }

        public DateTime DateOfConduct { get; set; }


        [StringLength(100, MinimumLength = 3)]
        public string Location { get; set; } = null!;

        
        public int MaxParticipants { get; set; }

        
        public bool IsFull { get; set; }

        
        public bool IsActive { get; set; }


        public CompetitionType CompetitionType { get; set; } = null!;


        public Subject Subject { get; set; } = null!;

        public List<ApplicationUser> Users { get; set; } = null!;

    }

}
