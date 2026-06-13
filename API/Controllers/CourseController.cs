using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CourseController: BaseController
    {
        private readonly StoreContext _context;

        public CourseController(StoreContext context)
        {
            _context = context;
        }
        
        // GET Course Request
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
        
        // GET Single Course
        [HttpGet("{id}")]

        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            return await _context.Courses.FindAsync(id);
        }
    }
}