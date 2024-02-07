using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace KursovaRabota.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        //add user properties
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [MinLength(1)]
        [MaxLength(50)]
        public string? Class { get; set; } = null!;

        public bool Approved { get; set; }


        public List<Subject> TeacherSubjects { get; set; } = null!;

        public List<Competition> Competitions { get; set; } = null!;
    }
}
