using System.ComponentModel.DataAnnotations;

namespace SchoolTest.Models;

public class Student
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Please enter the student´s name")]
    [StringLength(90)]
    public string? Name { get; set; }

    [Display(Name = "Lastname")]
    [Required(ErrorMessage = "Please enter the student´s lastname")]
    [StringLength(90)]
    public string? LastName { get; set; }

    [Display(Name = "Birthday")]
    [Required(ErrorMessage = "Please the date of birth")]
    public DateTime? Birthday { get; set; }

    public Genre? Genre { get; set; }

    [Display(Name = "Gender")]
    [Required(ErrorMessage = "Please enter the student´s genre")]
    public int GenreId { get; set; }

    public bool Active { get; set; }
}
