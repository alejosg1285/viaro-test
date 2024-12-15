using SchoolTest.Models;

namespace SchoolTest.ViewModel;

public class TeacherFormViewModel
{
    public Teacher? Teacher { get; set; }
    public IEnumerable<Genre>? Genres { get; set; }
}
