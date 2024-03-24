using System.ComponentModel.DataAnnotations;

using KursovaRabota.Data.Models;
using KursovaRabota.ViewModels.CompetitionTypeVMs;
using KursovaRabota.ViewModels.SubjectVMs;

namespace KursovaRabota.ViewModels.CompetitionVMs
{
    public class CompetitionUpdateViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Полето Име е задължително.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Полето Описание е задължително.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Полето Срок за регистрация е задължително.")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDeadline { get; set; }

        [Required(ErrorMessage = "Полето Местоположение е задължително.")]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "Полето Максимален брой участници е задължително.")]
        [Range(1, int.MaxValue, ErrorMessage = "Максималният брой участници трябва да бъде по-голям от 0.")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "Полето Предмет е задължително.")]
        public Guid SubjectId { get; set; }

        public List<SubjectViewModel>? Subjects { get; set; } = null!;

        [Required(ErrorMessage = "Полето Тип състезание е задължително.")]
        public Guid CompetitionTypeId { get; set; }

        public List<CompetitionTypeViewModel>? CompetitionTypes { get; set; } = null!;
    }
}
