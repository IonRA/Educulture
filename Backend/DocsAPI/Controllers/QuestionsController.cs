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
    public class QuestionsController : ControllerBase
    {
	    private IQuestionManager _questionManager;

	    public QuestionsController(IQuestionManager questionManager)
	    {
		    _questionManager = questionManager;
	    }

	    [HttpGet("GetAllQuestions")]
	    public async Task<IActionResult> GetAllQuestions()
	    {
            try
            {
                var questions = await _questionManager.GetAllAsync();

                if (questions == null)
                    return NotFound();

                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpPost("CreateQuestion")]
	    public async Task<IActionResult> CreateQuestion(Question question)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _questionManager.CreateAsync(question);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpPut("UpdateQuestion")]
	    public async Task<IActionResult> UpdateQuestion(Question question)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var quest = await _questionManager.UpdateAsync(question);

                if (quest == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpDelete("DeleteQuestion")]
	    public async Task<IActionResult> DeleteQuestion(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

		    try
            {
                await _questionManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	}
}