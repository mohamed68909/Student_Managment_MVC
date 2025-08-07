using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Data;
using Student_Managmet_MVC.Filter;
using Student_Managmet_MVC.Models;
using Student_Managmet_MVC.Service.Interface;


    namespace Student_Managmet_MVC.Controllers
    {

    public class StudentsController : Controller
        {
            private readonly IStudentService _studentService;
            private readonly IDepartmentService _departmentService;

            public StudentsController(IStudentService studentService, IDepartmentService departmentService)
            {
                _studentService = studentService;
                _departmentService = departmentService;
            }

            public async Task<IActionResult> Index()
            {
                var students = await _studentService.GetAllAsync();
                return View(students);
            }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                    return NotFound();

                var student = await _studentService.GetByIdAsync(id.Value);
                if (student == null)
                    return NotFound();

                return View(student);
            }

            public async Task<IActionResult> Create()
            {
                var departments = await _departmentService.GetAllAsync();
                ViewData["DapartmantId"] = new SelectList(departments, "Id", "Name");
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            [LoggingFliter]
            public async Task<IActionResult> Create(Student student)
            {
                if (ModelState.IsValid)
                {
                    await _studentService.CreateAsync(student);
                    return RedirectToAction(nameof(Index));
                }

                var departments = await _departmentService.GetAllAsync();
                ViewData["DapartmantId"] = new SelectList(departments, "Id", "Name", student.DapartmantId);
                return View(student);
            }

            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                    return NotFound();

                var student = await _studentService.GetByIdAsync(id.Value);
                if (student == null)
                    return NotFound();

                var departments = await _departmentService.GetAllAsync();
                ViewData["DapartmantId"] = new SelectList(departments, "Id", "Name", student.DapartmantId);
                return View(student);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Student student)
            {
                if (id != student.Id)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    await _studentService.UpdateAsync(student);
                    return RedirectToAction(nameof(Index));
                }

                var departments = await _departmentService.GetAllAsync();
                ViewData["DapartmantId"] = new SelectList(departments, "Id", "Name", student.DapartmantId);
                return View(student);
            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                    return NotFound();

                var student = await _studentService.GetByIdAsync(id.Value);
                if (student == null)
                    return NotFound();

                return View(student);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _studentService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }





