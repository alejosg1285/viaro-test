using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolTest.Models;

public class StudentGrade
{
    public int Id { get; set; }

    public Student? Student { get; set; }

    [Display(Name = "Student")]
    [Required(ErrorMessage = "Please enter the student")]
    public int StudentId { get; set; }

    public Grade? Grade { get; set; }

    [Display(Name = "Grade")]
    [Required(ErrorMessage = "Please enter the grade")]
    public int GradeId { get; set; }

    [Display(Name = "Section")]
    [Required(ErrorMessage = "Please enter the section")]
    [StringLength(50)]
    public string? Section { get; set; }
}
