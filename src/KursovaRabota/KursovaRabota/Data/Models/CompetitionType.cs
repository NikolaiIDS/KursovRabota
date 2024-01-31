using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Data.Models
{
    public class CompetitionType
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public string Type { get; set; } = null!;
    }
}
