using KursovaRabota.ViewModels.CompetitionVMs;
using KursovaRabota.ViewModels.SubjectVMs;

namespace KursovaRabota.ViewModels.CompetitionVMs
{
    public class CompetitionGetAllViewModel
    {
        //Pagination
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int CurrentPage { get; set; }
        //Filtration
        public List<SubjectViewModel>? Subjects { get; set; }
        public SubjectViewModel? Subject { get; set; }
        public string? PlaceOfConduct { get; set; }
        public DateTime DateOfConduct { get; set; }

        public bool? SortByDate { get; set; }

        public List<CompetitionGetViewModel> Competitions { get; set; }
    }
}
