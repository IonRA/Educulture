using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
	    private ICourseManager _courseManager;

	    public CoursesController(ICourseManager courseManager)
	    {
		    _courseManager = courseManager;
	    }

	    [HttpGet("GetAllCourses")]
	    public async Task<IActionResult> GetAllCourses()
	    {
            try
            {
                var courses = await _courseManager.GetAllAsync();

                if (courses == null)
                    return NotFound();

                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpGet("GetCourseById/{id}")]
	    public async Task<IActionResult> GetCourseById(int id)
	    {
		    if (id <= 0)
		    {
			    return BadRequest("The given Id is not valid. Id must be greater than 0");
		    }

            try
		    {
			    var course = await _courseManager.GetAsync(x => x.Id == id);

			    if (course == null)
				    return NotFound();

			    return Ok(course);
		    }
		    catch (Exception ex)
		    {
			    return StatusCode(500, ex.Message);
		    }
	    }

        [HttpPost("CreateCourse")]
	    public async Task<IActionResult> CreateCourse(Course course)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _courseManager.CreateAsync(course);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpPut("UpdateCourse")]
	    public async Task<IActionResult> UpdateCourse(Course course)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var updatedCourse = await _courseManager.UpdateAsync(course);

                if (updatedCourse == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpDelete("DeleteCourse/{id}")]
	    public async Task<IActionResult> DeleteCourse(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _courseManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }


	}
}