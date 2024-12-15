using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTest.Data;
using SchoolTest.Models;
using SchoolTest.ViewModel;

namespace SchoolTest.Controllers;

public class GradeController(SchoolContext context) : Controller
{
    private readonly SchoolContext _context = context;

    // GET: GradeController
    public ActionResult Index()
    {
        List<Grade> grades = _context.Grades.Include(t => t.Teacher).Where(g => g.Active).ToList();
        return View(grades);
    }

    // GET: GradeController/Create
    public ActionResult Create()
    {
        GradeFormViewModel viewModel = new GradeFormViewModel
        {
            Grade = new(),
            Teachers = _context.Teachers.Where(t => t.Active).ToList(),
        };
        return View("GradeForm", viewModel);
    }

    // GET: TeacherController/Edit/5
    public ActionResult Edit(int id)
    {
        Grade grade = _context.Grades.Find(id);
        if (grade is null)
        {
            return NotFound();
        }

        GradeFormViewModel viewModel = new GradeFormViewModel
        {
            Grade = grade,
            Teachers = _context.Teachers.Where(t => t.Active).ToList(),
        };
        return View("GradeForm", viewModel);
    }

    // GET: GradeController/Delete/5
    public ActionResult Delete(int id)
    {
        Grade grade = _context.Grades.Find(id);
        if (grade is null)
        {
            return NotFound();
        }

        return View("Delete", grade);
    }

    // POST: GradeController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Grade grade)
    {
        if (!ModelState.IsValid)
        {
            return View("GradeForm", grade);
        }

        if (grade.Id == 0)
        {
            grade.Active = true;
            _context.Grades.Add(grade);
        }
        else
        {
            Grade gradeDb = _context.Grades.Find(grade.Id);
            gradeDb.Name = grade.Name;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Grade");
    }

    // POST: GradeController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Grade grade)
    {
        Grade gradeDb = _context.Grades.Find(grade.Id);
        gradeDb.Active = false;
        _context.SaveChanges();

        return RedirectToAction("Index", "Grade");
    }
}
