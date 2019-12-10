﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFinalProject.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFinalProject.Controllers
{
    public class CourseAssignmentController : Controller
    {
        // GET: /<controller>/
        private readonly UTEUniversityContext _context;
        public CourseAssignmentController(UTEUniversityContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var courseAssigment = _context.CourseAssignments
                .Include(i => i.Course)
                .Include(i => i.Instructor)
                .AsNoTracking();
                
            return View(await courseAssigment.ToListAsync());
        }
    }
}
