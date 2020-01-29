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
    public class RanksController : ControllerBase
    {
	    private IRankManager _rankManager;

	    public RanksController(IRankManager rankManager)
	    {
		    _rankManager = rankManager;
	    }

		[HttpGet("GetAllRanks")]
	    public async Task GetAllRanks()
	    {
		    await _rankManager.GetAllAsync();
	    }

	    [HttpPost("CreateRank")]
	    public async Task CreateRank(Rank rank)
	    {
		    await _rankManager.CreateAsync(rank);
	    }

	    [HttpPut("UpdateRank")]
	    public async Task UpdateRank(Rank rank)
	    {
		    await _rankManager.UpdateAsync(rank);
	    }

	    [HttpDelete("DeleteRank")]
	    public async Task DeleteRank(int id)
	    {
		    await _rankManager.DeleteAsync(id);
	    }
	}
}