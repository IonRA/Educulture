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
	    public async Task GetAllQuestions()
	    {
		    await _questionManager.GetAllAsync();
	    }

	    [HttpPost("CreateQuestion")]
	    public async Task CreateQuestion(Question question)
	    {
		    await _questionManager.CreateAsync(question);
	    }

	    [HttpPut("UpdateQuestion")]
	    public async Task UpdateQuestion(Question question)
	    {
		    await _questionManager.UpdateAsync(question);
	    }

	    [HttpDelete("DeleteQuestion")]
	    public async Task DeleteQuestion(int id)
	    {
		    await _questionManager.DeleteAsync(id);
	    }

	}
}