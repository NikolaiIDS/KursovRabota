using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.ViewModels
{
    public class SubjectViewModel
    {
        public string? Id { get; set; }
        [MinLength(1, ErrorMessage ="Името на предмета трябва да е минимум 1 символ.")]
        [MaxLength(50, ErrorMessage = "Името на предмета трябв да е максимум 50 символа.")]
        public string SubjectName { get; set; } = null!;

        public List<SubjectViewModel>? Subjects { get; set; }
    }
}
