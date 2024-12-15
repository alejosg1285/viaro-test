using SchoolTest.Models;

namespace SchoolTest.ViewModel;

public class GradeFormViewModel
{
    public Grade? Grade { get; set; }
    public IEnumerable<Teacher>? Teachers { get; set; }
}
