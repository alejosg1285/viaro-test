using System.ComponentModel.DataAnnotations;

namespace SchoolTest.Models;

public class Teacher
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Please enter the teacher´s name")]
    [StringLength(90)]
    public string? Name { get; set; }

    [Display(Name = "Lastname")]
    [Required(ErrorMessage = "Please enter the teacher´s lastnane")]
    [StringLength(90)]
    public string? Lastname { get; set; }

    public Genre? Genre { get; set; }

    [Display(Name = "Gender")]
    [Required(ErrorMessage = "Please enter the teacher´s genre")]
    public int GenreId { get; set; }

    public bool Active { get; set; }
}
