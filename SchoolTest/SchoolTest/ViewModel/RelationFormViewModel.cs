using SchoolTest.Models;

namespace SchoolTest.ViewModel;

public class RelationFormViewModel
{
    public IEnumerable<Student>? Students { get; set; }
    public IEnumerable<Grade>? Grades { get; set; }
    public StudentGrade? StudentGrade { get; set; }
}
