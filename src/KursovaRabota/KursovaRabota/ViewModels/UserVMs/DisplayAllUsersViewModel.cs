using KursovaRabota.ViewModels.SubjectVMs;

namespace KursovaRabota.ViewModels.UserVMs
{
    public class DisplayAllUsersViewModel
    {
        public List<DisplayUserViewModel>? Users { get; set; }

        public List<SubjectViewModel>? Subjects { get; set; }
        public SubjectViewModel? SelectedSubject { get; set; }
    }
}
