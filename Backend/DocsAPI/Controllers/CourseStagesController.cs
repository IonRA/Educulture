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
    public class CourseStagesController : ControllerBase
    {
        private readonly ICourseStageManager _courseStageManager;

        public CourseStagesController(ICourseStageManager courseStageManager)
        {
	        _courseStageManager = courseStageManager;
        }

        [HttpGet("GetAllCourseStages")]
        public async Task<IActionResult> GetAllCourseStages()
        {
            try
            {
                var answers = await _courseStageManager.GetAllAsync();

                if (answers == null)
                    return NotFound();

                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCourseStageById/{id}")]
        public async Task<IActionResult> GetCourseStageById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The given Id is not valid. Id must be greater than 0");
            }

            try
            {
                var answer = await _courseStageManager.GetAsync(x => x.Id == id);

                if (answer == null)
                    return NotFound();

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCourseStagesByCourseId/{id}")]
        public async Task<IActionResult> GetCourseStagesByCourseId(int id)
        {
	        if (id <= 0)
	        {
		        return BadRequest("The given Id is not valid. Id must be greater than 0");
	        }

	        try
	        {
		        var answer = await _courseStageManager.GetAllAsync(x => x.CourseId == id);

		        if (answer == null)
			        return NotFound();

		        return Ok(answer);
	        }
	        catch (Exception ex)
	        {
		        return StatusCode(500, ex.Message);
	        }
        }

        [HttpPost("CreateCourseStage")]
        public async Task<IActionResult> CreateCourseStage(CourseStage courseStage)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _courseStageManager.CreateAsync(courseStage);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateCourseStage")]
        public async Task<IActionResult> UpdateAnswer(CourseStage courseStage)
        {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var course = await _courseStageManager.UpdateAsync(courseStage);

                if (course == null)
                    return NotFound();

                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteCourseStage/{id}")]
        public async Task<IActionResult> DeleteCourseStage(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _courseStageManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}