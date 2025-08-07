using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Data;
using Student_Managmet_MVC.Models;

namespace Student_Managmet_MVC.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly AppsContext _context;

        public AttendancesController(AppsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appsContext = _context.Attendances.Include(a => a.Course).Include(a => a.Student);
            return View(await appsContext.ToListAsync());
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Course)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
          
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName"] = new SelectList(_context.Courses, "Id", "Name", attendance.CourseId);
            ViewData["StudentName"] = new SelectList(_context.Students, "Id", "Name", attendance.StudentId);
          
            return View(attendance);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", attendance.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", attendance.StudentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", attendance.StudentId);
            return View(attendance);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
             
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", attendance.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", attendance.StudentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email", attendance.StudentId);
            return View(attendance);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Course)
                .Include(a => a.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
