using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.Data.Models
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(1)]
        [MaxLength(50)]
        public string SubjectName { get; set; } = null!;
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    }
}
