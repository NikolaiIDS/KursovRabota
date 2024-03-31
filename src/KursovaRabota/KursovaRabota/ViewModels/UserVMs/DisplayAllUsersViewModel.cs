using KursovaRabota.ViewModels.SubjectVMs;

namespace KursovaRabota.ViewModels.UserVMs
{
    public class DisplayAllUsersViewModel
    {
        public List<DisplayUserViewModel>? Users { get; set; }

        public List<SubjectViewModel>? Subjects { get; set; }


        //Filtration
        public string? Class { get; set; }
        public bool SortByName { get; set; }
        public SubjectViewModel? SelectedSubject { get; set; }
        public string? Name { get; set; }
    }
}
