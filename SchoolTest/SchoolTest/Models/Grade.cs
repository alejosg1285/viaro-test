using System.ComponentModel.DataAnnotations;

namespace SchoolTest.Models;

public class Grade
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Please enter the grade´s name")]
    [StringLength(120)]
    public string? Name { get; set; }

    public Teacher? Teacher { get; set; }

    [Display(Name = "Teacher")]
    [Required(ErrorMessage = "Please enter the grade´s teacher")]
    public int Teacherid { get; set; }

    public bool Active { get; set; }
}
