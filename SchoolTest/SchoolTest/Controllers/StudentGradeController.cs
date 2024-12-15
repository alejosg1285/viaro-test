using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTest.Data;
using SchoolTest.Models;
using SchoolTest.ViewModel;

namespace SchoolTest.Controllers;

public class StudentGradeController(SchoolContext context) : Controller
{
    private readonly SchoolContext _context = context;

    // GET: RelationController
    public ActionResult Index()
    {
        List<StudentGrade> list = _context.StudentGrades.Include(s => s.Student).Include(g => g.Grade).ToList();
        return View(list);
    }

    // GET: RelationController/Create
    public ActionResult Create()
    {
        RelationFormViewModel viewModel = new RelationFormViewModel
        {
            Grades = _context.Grades.Where(g => g.Active).ToList(),
            Students = _context.Students.Where(s => s.Active).ToList(),
            StudentGrade = new()
        };

        return View("RelationForm", viewModel);
    }

    // GET: RelationController/Edit/5
    public ActionResult Edit(int id)
    {
        StudentGrade item = _context.StudentGrades.Include(s => s.Student).Include(g => g.Grade).FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            return NotFound();
        }

        RelationFormViewModel viewModel = new RelationFormViewModel
        {
            Grades = _context.Grades.Where(g => g.Active).ToList(),
            Students = _context.Students.Where(s => s.Active).ToList(),
            StudentGrade = item
        };

        return View("RelationForm", viewModel);
    }

    // GET: RelationController/Delete/5
    public ActionResult Delete(int id)
    {
        StudentGrade item = _context.StudentGrades.Include(s => s.Student).Include(g => g.Grade).FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            return NotFound();
        }

        return View();
    }

    // POST: RelationController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(RelationFormViewModel item)
    {
        if (!ModelState.IsValid)
        {
            RelationFormViewModel viewModel = new RelationFormViewModel
            {
                Grades = _context.Grades.Where(g => g.Active).ToList(),
                Students = _context.Students.Where(s => s.Active).ToList(),
                StudentGrade = item.StudentGrade
            };

            return View("RelationForm", viewModel);
        }

        if (item.StudentGrade.Id == 0)
        {
            _context.StudentGrades.Add(item.StudentGrade);
        }
        else
        {
            StudentGrade itemDb = _context.StudentGrades.Find(item.StudentGrade.Id);
            itemDb.Section = item.StudentGrade.Section;
            itemDb.StudentId = item.StudentGrade.StudentId;
            itemDb.GradeId = item.StudentGrade.GradeId;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "StudentGrade");
    }

    // POST: RelationController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(StudentGrade item)
    {
        StudentGrade itemDb = _context.StudentGrades.Find(item.Id);
        _context.StudentGrades.Remove(itemDb);
        _context.SaveChanges();

        return RedirectToAction("Index", "StudentGrade");
    }
}
