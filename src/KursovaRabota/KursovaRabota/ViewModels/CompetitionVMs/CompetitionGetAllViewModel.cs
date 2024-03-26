using KursovaRabota.ViewModels.CompetitionVMs;

namespace KursovaRabota.ViewModels.CompetitionVMs
{
    public class CompetitionGetAllViewModel
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int CurrentPage { get; set; }
        public List<CompetitionGetViewModel> Competitions { get; set; }
    }
}
