using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
	    private IAuthorManager _authorManager;

	    public AuthorsController(IAuthorManager authorManager)
	    {
		    _authorManager = authorManager;
	    }

	    [HttpGet("GetAllAuthors")]
	    public async Task GetAllAuthors()
	    {
		    await _authorManager.GetAllAsync();
	    }
	}
}