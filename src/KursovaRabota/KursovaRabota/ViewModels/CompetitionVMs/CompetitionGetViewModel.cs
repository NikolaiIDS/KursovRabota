using KursovaRabota.Data.Models;

namespace KursovaRabota.ViewModels.CompetitionVMs
{
    public class CompetitionGetViewModel
    {
        public Guid? Id { get; set; }


        public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;


        public DateTime RegistrationDeadline { get; set; }


        public string Location { get; set; } = null!;


        public int MaxParticipants { get; set; }


        public bool IsFull { get; set; }


        public bool IsActive { get; set; }


        public CompetitionType CompetitionType { get; set; } = null!;


        public Subject Subject { get; set; } = null!;
    }
}
