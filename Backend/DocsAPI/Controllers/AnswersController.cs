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
    public class AnswersController : ControllerBase
    {
	    private IAnswerManager _answerManager;

	    public AnswersController(IAnswerManager answerManager)
	    {
		    _answerManager = answerManager;
	    }

	    [HttpGet("GetAllAnswers")]
	    public async Task GetAllAnswers()
	    {
		    await _answerManager.GetAllAsync();
	    }
    }
}