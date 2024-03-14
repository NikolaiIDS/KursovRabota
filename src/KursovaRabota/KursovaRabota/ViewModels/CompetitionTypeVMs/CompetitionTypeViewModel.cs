using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.ViewModels.CompetitionTypeVMs
{
    public class CompetitionTypeViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public string Type { get; set; } = null!;

        public List<CompetitionTypeViewModel>? AllTypes { get; set; }

    }
}
