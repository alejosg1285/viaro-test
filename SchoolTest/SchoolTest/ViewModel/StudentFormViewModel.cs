using SchoolTest.Models;

namespace SchoolTest.ViewModel;

public class StudentFormViewModel
{
    public Student? Student { get; set; }
    public IEnumerable<Genre>? Genres { get; set; }
}
