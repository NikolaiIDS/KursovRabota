using KursovaRabota.ViewModels.CompetitionVMs;

namespace KursovaRabota.ViewModels.CompetitionVMs
{
    public class CompetitionGetAllViewModel
    {
        public int TotalCompetitions { get; set; } // Total number of competitions
        public int PageNumber { get; set; }// Current page number
        public int PageSize { get; set; } // Number of competitions per page
        public List<CompetitionGetViewModel> Competitions { get; set; }
    }
}
