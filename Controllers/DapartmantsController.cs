using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Managmet_MVC.Data;
using Student_Managmet_MVC.Filter;
using Student_Managmet_MVC.Models;
using Student_Managmet_MVC.Service.Interface;

namespace Student_Managmet_MVC.Controllers
{

    public class DapartmantsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DapartmantsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();
            return View(departments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var department = await _departmentService.GetByIdAsync(id.Value);
            if (department == null) return NotFound();

            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoggingFliter]
        public async Task<IActionResult> Create(Dapartmant dapartmant)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.CreateAsync(dapartmant);
                return RedirectToAction(nameof(Index));
            }

            return View(dapartmant);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var department = await _departmentService.GetByIdAsync(id.Value);
            if (department == null) return NotFound();

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Dapartmant dapartmant)
        {
            if (id != dapartmant.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _departmentService.UpdateAsync(dapartmant);
                return RedirectToAction(nameof(Index));
            }

            return View(dapartmant);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var department = await _departmentService.GetByIdAsync(id.Value);
            if (department == null) return NotFound();

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }


}

