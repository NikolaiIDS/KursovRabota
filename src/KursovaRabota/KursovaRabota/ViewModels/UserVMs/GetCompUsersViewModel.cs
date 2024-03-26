using KursovaRabota.Data.Models;

namespace KursovaRabota.ViewModels.UserVMs
{
    public class GetCompUsersViewModel
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int CurrentPage { get; set; }
        public List<ApplicationUser>? Students { get; set; }

    }
}
