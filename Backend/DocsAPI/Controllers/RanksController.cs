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
	    public async Task<IActionResult> GetAllRanks()
	    {
            try
            {
                var ranks = await _rankManager.GetAllAsync();

                if (ranks == null)
                    return NotFound();

                return Ok(ranks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpGet("GetRankById/{id}")]
	    public async Task<IActionResult> GetRankById(int id)
	    {
		    if (id <= 0)
		    {
			    return BadRequest("The given Id is not valid. Id must be greater than 0");
		    }

            try
		    {
			    var rank = await _rankManager.GetAsync(x => x.Id == id);

			    if (rank == null)
				    return NotFound();

			    return Ok(rank);
		    }
		    catch (Exception ex)
		    {
			    return StatusCode(500, ex.Message);
		    }
	    }

        [HttpPost("CreateRank")]
	    public async Task<IActionResult> CreateRank(Rank rank)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _rankManager.CreateAsync(rank);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpPut("UpdateRank")]
	    public async Task<IActionResult> UpdateRank(Rank rank)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var updatedRank = await _rankManager.UpdateAsync(rank);

                if (updatedRank == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpDelete("DeleteRank")]
	    public async Task<IActionResult> DeleteRank(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _rankManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
	}
}