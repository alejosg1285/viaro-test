using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTest.Data;
using SchoolTest.Models;
using SchoolTest.ViewModel;

namespace SchoolTest.Controllers;

public class TeacherController(SchoolContext context) : Controller
{
    private readonly SchoolContext _context = context;

    // GET: TeacherController
    public ActionResult Index()
    {
        List<Teacher> teachers = _context.Teachers.Include(g => g.Genre).Where(t => t.Active).ToList();
        return View(teachers);
    }

    // GET: TeacherController/Create
    public ActionResult Create()
    {
        TeacherFormViewModel viewModel = new TeacherFormViewModel
        {
            Teacher = new(),
            Genres = _context.Genres.ToList(),
        };

        return View("TeacherForm", viewModel);
    }

    // GET: TeacherController/Edit/5
    public ActionResult Edit(int id)
    {
        Teacher teacher = _context.Teachers.Include(g => g.Genre).FirstOrDefault(t => t.Id == id);
        if (teacher is null)
        {
            return NotFound();
        }

        TeacherFormViewModel viewModel = new TeacherFormViewModel
        {
            Teacher = teacher,
            Genres = _context.Genres.ToList(),
        };

        return View("TeacherForm", viewModel);
    }

    // GET: TeacherController/Delete/5
    public ActionResult Delete(int id)
    {
        Teacher teacher = _context.Teachers.Include(g => g.Genre).FirstOrDefault(t => t.Id == id);
        if (teacher is null)
        {
            return NotFound();
        }

        TeacherFormViewModel viewModel = new TeacherFormViewModel
        {
            Teacher = teacher,
            Genres = _context.Genres.ToList(),
        };

        return View(viewModel);
    }

    // POST: TeacherController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            TeacherFormViewModel viewModel = new TeacherFormViewModel
            {
                Teacher = teacher,
                Genres = _context.Genres.ToList(),
            };

            return View("TeacherForm", viewModel);
        }

        if (teacher.Id == 0)
        {
            teacher.Active = true;
            _context.Teachers.Add(teacher);
        }
        else
        {
            Teacher teacherDb = _context.Teachers.Find(teacher.Id);
            teacherDb.Name = teacher.Name;
            teacherDb.Lastname = teacher.Lastname;
            teacherDb.GenreId = teacher.GenreId;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Teacher");
    }

    // POST: TeacherController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Teacher teacher)
    {
        Teacher teacherDb = _context.Teachers.Find(teacher.Id);
        teacherDb.Active = false;
        _context.SaveChanges();

        return RedirectToAction("Index", "Teacher");
    }
}
