using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class CourseController: BaseController
    {
        private readonly ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }
        
        // GET Course Request
        [HttpGet]
        public async Task<ActionResult<Course>> GetCourses()
        {
            var courses = await _repository.GetCoursesAsync();
            return Ok(courses);
        }
        
        // GET Single Course
        [HttpGet("{id}")]

        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _repository.GetCourseByIdAsync(id);
            return Ok(course);
        }
    }
}