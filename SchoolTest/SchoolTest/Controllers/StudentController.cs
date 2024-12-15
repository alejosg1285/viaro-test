using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTest.Data;
using SchoolTest.Models;
using SchoolTest.ViewModel;

namespace SchoolTest.Controllers;

public class StudentController(SchoolContext context) : Controller
{
    private readonly SchoolContext _context = context;

    public IActionResult Index()
    {
        List<Student> students = _context.Students.Include(g => g.Genre).Where(s => s.Active).ToList();
        return View(students);
    }

    public IActionResult New()
    {
        StudentFormViewModel viewModel = new StudentFormViewModel
        {
            Student = new(),
            Genres = _context.Genres.ToList(),
        };

        return View("StudentForm", viewModel);
    }

    public IActionResult Edit(int id)
    {
        Student student = _context.Students.Include(g => g.Genre).FirstOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        StudentFormViewModel viewModel = new StudentFormViewModel
        {
            Student = student,
            Genres = _context.Genres.ToList(),
        };

        return View("StudentForm", viewModel);
    }

    public IActionResult Delete(int id)
    {
        Student student = _context.Students.Include(g => g.Genre).SingleOrDefault(s => s.Id == id);
        if (student is null)
        {
            return NotFound();
        }

        StudentFormViewModel viewModel = new StudentFormViewModel
        {
            Student = student,
            Genres = _context.Genres.ToList(),
        };

        return View("Delete", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Student student)
    {
        if (!ModelState.IsValid)
        {
            StudentFormViewModel viewModel = new StudentFormViewModel
            {
                Student = student,
                Genres = _context.Genres.ToList(),
            };

            return View("StudentForm", viewModel);
        }

        if (student.Id == 0)
        {
            student.Active = true;
            _context.Students.Add(student);
        }
        else
        {
            Student studentDb = _context.Students.Find(student.Id)!;
            studentDb.Name = student.Name;
            studentDb.LastName = student.LastName;
            studentDb.GenreId = student.GenreId;
            studentDb.Birthday = student.Birthday;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Student");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Student student)
    {
        Student studentDb = _context.Students.Find(student.Id)!;

        studentDb.Active = false;
        _context.SaveChanges();

        return RedirectToAction("Index", "Student");
    }
}
