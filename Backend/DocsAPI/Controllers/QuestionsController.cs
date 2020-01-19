using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
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

	}
}