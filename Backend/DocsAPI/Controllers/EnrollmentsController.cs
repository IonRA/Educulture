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
    public class EnrollmentsController : ControllerBase
    {
	    private IEnrollmentManager _enrollmentManager;

	    public EnrollmentsController(IEnrollmentManager enrollmentManager)
	    {
		    _enrollmentManager = enrollmentManager;
	    }

	    [HttpGet("GetAllEnrollments")]
	    public async Task<IActionResult> GetAllEnrollments()
	    {
            try
            {
                var enrollments = await _enrollmentManager.GetAllAsync();

                if (enrollments == null)
                    return NotFound();

                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpGet("GetEnrollmentById/{id}")]
	    public async Task<IActionResult> GetEnrollmentById(int id)
	    {
		    if (id <= 0)
		    {
			    return BadRequest("The given Id is not valid. Id must be greater than 0");
		    }

            try
		    {
			    var enrollment = await _enrollmentManager.GetAsync(x => x.Id == id);

			    if (enrollment == null)
				    return NotFound();

			    return Ok(enrollment);
		    }
		    catch (Exception ex)
		    {
			    return StatusCode(500, ex.Message);
		    }
	    }

        [HttpPost("CreateEnrollment")]
	    public async Task<IActionResult> CreateEnrollment(Enrollment enrollment)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _enrollmentManager.CreateAsync(enrollment);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpPut("UpdateEnrollment")]
	    public async Task<IActionResult> UpdateEnrollment(Enrollment enrollment)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var enroll = await _enrollmentManager.UpdateAsync(enrollment);

                if (enroll == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpDelete("DeleteEnrollment/{id}")]
	    public async Task<IActionResult> DeleteEnrollment(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _enrollmentManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
	}
}