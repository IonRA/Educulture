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

	    [HttpPost("CreateUser")]
	    public async Task CreateUser(User user)
	    {
		    await _userManager.CreateAsync(user);
	    }

	    [HttpPut("UpdateUser")]
	    public async Task UpdateUser(User user)
	    {
		    await _userManager.UpdateAsync(user);
	    }

	    [HttpDelete("DeleteUser")]
	    public async Task DeleteUser(int id)
	    {
		    await _userManager.DeleteAsync(id);
	    }
	}
}