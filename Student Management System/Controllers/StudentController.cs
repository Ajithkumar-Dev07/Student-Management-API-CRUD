using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.Models;

namespace Student_Management_System.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var stu = _context.student.ToList();
            if(stu == null)
            {
                return NotFound();
            }
            return View(stu);
        }

        public IActionResult Details(int id)
        {
           var studentRec = _context.student.FirstOrDefault(s => s.StudentId == id);

            if(studentRec == null)
            {
                return NotFound();
            }

            return View(studentRec);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent(Students stu)
        {
            if(ModelState.IsValid)
            {
                _context.student.Add(stu);
                _context.SaveChanges();
                TempData["Success"] = "student Added Successful";
                return RedirectToAction("GetAllStudents");
            }

            return View("Create", stu);
           
        }

        
        public IActionResult Edit(int id)
        {
            var stu = _context.student.FirstOrDefault(s => s.StudentId == id);

            if (stu == null)
                return NotFound();

            return View(stu);
        }

        [HttpPost]
        public IActionResult Edit(int id, Students stu)
        {
            if (stu.StudentId != id)
                return NotFound();

            if(ModelState.IsValid)
            {
                _context.student.Update(stu);
                _context.SaveChanges();
                TempData["Success"] = "Student Updated Successfully";
            }

            return RedirectToAction("GetAllStudents");
        }

        
        public IActionResult Delete(int id)
        {
            var stu = _context.student.FirstOrDefault(s => s.StudentId == id);

            if(stu == null)
            {
                return NotFound();
            }

            return View(stu);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var stu = _context.student.Find(id);

            if(stu != null)
            {
                _context.student.Remove(stu);
                _context.SaveChanges();
            }

            TempData["success"] = "Student Deleted Successful";
            return RedirectToAction("GetAllStudents");
        }
    }
}
