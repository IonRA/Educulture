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
    public class UsersController : ControllerBase
    {
	    private IUserManager _userManager;

	    public UsersController(IUserManager userManager)
	    {
		    _userManager = userManager;
	    }

	    [HttpGet("GetAllUsers")]
	    public async Task GetAllUsers()
	    {
		    await _userManager.GetAllAsync();
	    }
	}
}