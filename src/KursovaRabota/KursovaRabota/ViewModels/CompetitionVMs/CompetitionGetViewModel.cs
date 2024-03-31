using KursovaRabota.Data.Models;
using KursovaRabota.ViewModels.SubjectVMs;

using System;
using System.Collections.Generic;

namespace KursovaRabota.ViewModels.CompetitionVMs
{
    public class CompetitionGetViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateOfConduct { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public string Location { get; set; } = null!;
        public int MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }
        public bool IsFull { get; set; }
        public bool IsActive { get; set; }
        public CompetitionType CompetitionType { get; set; } = null!;
        public string? CompetitionName { get; set; }
        public SubjectViewModel Subject { get; set; } = null!;
        public List<ApplicationUser> Users { get; set; }



    }
}
