using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DocsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
	    private readonly IAnswerManager _answerManager;

	    public AnswersController(IAnswerManager answerManager)
	    {
		    _answerManager = answerManager;
	    }

	    [HttpGet("GetAllAnswers")]
	    public async Task<IActionResult> GetAllAnswers()
	    {
            try
            {
                var answers = await _answerManager.GetAllAsync();

                if (answers == null)
                    return NotFound();

                return Ok(answers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpGet("GetAnswerById/{id}")]
	    public async Task<IActionResult> GetAnswerById(int id)
	    {
		    if (id <= 0)
		    {
			    return BadRequest("The given Id is not valid. Id must be greater than 0");
		    }

		    try
		    {
			    var answer = await _answerManager.GetAsync(x => x.Id == id);

			    if (answer == null)
				    return NotFound();

			    return Ok(answer);
		    }
		    catch (Exception ex)
		    {
			    return StatusCode(500, ex.Message);
		    }
	    }

        [HttpPost("CreateAnswer")]
	    public async Task<IActionResult> CreateAnswer(Answer answer)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _answerManager.CreateAsync(answer);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpPut("UpdateAnswer")]
	    public async Task<IActionResult> UpdateAnswer(Answer answer)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var ans = await _answerManager.UpdateAsync(answer);

                if (ans == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpDelete("DeleteAnswer/{id}")]
	    public async Task<IActionResult> DeleteAnswer(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _answerManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
	}
}