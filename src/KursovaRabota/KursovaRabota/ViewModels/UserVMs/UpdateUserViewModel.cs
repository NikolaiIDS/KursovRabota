using KursovaRabota.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace KursovaRabota.ViewModels.UserVMs
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Личното име е задължително.")]
        [MinLength(1, ErrorMessage = "Личното име трябва да е най-малко 1 символ.")]
        [MaxLength(50, ErrorMessage = "Личното име трябва да е най-много 50 символа.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Фамилията е задължителна.")]
        [MinLength(1, ErrorMessage = "Фамилията трябва да е най-малко 1 символ.")]
        [MaxLength(50, ErrorMessage = "Фамилията трябва да е най-много 50 символа.")]
        public string LastName { get; set; } = null!;

        [MinLength(1, ErrorMessage = "Класът трябва да е най-малко 1 символ.")]
        [MaxLength(50, ErrorMessage = "Класът трябва да е най-много 50 символа.")]
        public string? Class { get; set; } = null!;

        [Required(ErrorMessage = "Потребителското име е задължително.")]
        [MinLength(1, ErrorMessage = "Потребителското име трябва да е най-малко 1 символ.")]
        [MaxLength(50, ErrorMessage = "Потребителското име трябва да е най-много 50 символа.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Имейлът е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Телефонният номер е задължителен.")]
        [Phone(ErrorMessage = "Невалиден телефонен номер.")]
        public string PhoneNumber { get; set; } = null!;

        public string DesiredRole { get; set; }

        public List<Subject>? TeacherSubjects { get; set; } = null!;

        public List<Guid>? SelectedSubjectIds { get; set; }


    }
}
