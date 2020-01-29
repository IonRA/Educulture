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
    public class RolesController : ControllerBase
    {
	    private IRoleManager _roleManager;

	    public RolesController(IRoleManager roleManager)
	    {
		    _roleManager = roleManager;
	    }

	    [HttpGet("GetAllRoles")]
	    public async Task GetAllRoles()
	    {
		    await _roleManager.GetAllAsync();
	    }

	    [HttpPost("CreateRole")]
	    public async Task CreateRole(Role role)
	    {
		    await _roleManager.CreateAsync(role);
	    }

	    [HttpPut("UpdateRole")]
	    public async Task UpdateRole(Role role)
	    {
		    await _roleManager.UpdateAsync(role);
	    }

	    [HttpDelete("DeleteRole")]
	    public async Task DeleteRole(int id)
	    {
		    await _roleManager.DeleteAsync(id);
	    }
	}
}