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
    public class AnswersController : ControllerBase
    {
	    private readonly IAnswerManager _answerManager;

	    public AnswersController(IAnswerManager answerManager)
	    {
		    _answerManager = answerManager;
	    }

	    [HttpGet("GetAllAnswers")]
	    public async Task GetAllAnswers()
	    {
		    await _answerManager.GetAllAsync();
	    }

	    [HttpPost("CreateAnswer")]
	    public async Task CreateAnswer(Answer answer)
	    {
		    await _answerManager.CreateAsync(answer);
	    }

	    [HttpPut("UpdateAnswer")]
	    public async Task UpdateAnswer(Answer answer)
	    {
		    await _answerManager.UpdateAsync(answer);
	    }

	    [HttpDelete("DeleteAnswer")]
	    public async Task DeleteAnswer(int id)
	    {
		    await _answerManager.DeleteAsync(id);
	    }
	}
}