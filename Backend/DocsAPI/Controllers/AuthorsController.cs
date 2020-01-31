using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Interfaces.IRepositories;
using Docs.Domain.Models;
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
	    public async Task<IActionResult> GetAllAuthors()
	    {
            try
            {
                var authors = await _authorManager.GetAllAsync();

                if (authors == null)
                    return NotFound();

                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpPost("CreateAuthor")]
	    public async Task<IActionResult> CreateAuthor(Author author)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                await _authorManager.CreateAsync(author);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpPut("UpdateAuthor")]
	    public async Task<IActionResult> UpdateAuthor(Author author)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var auth = await _authorManager.UpdateAsync(author);

                if (auth == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }

	    [HttpDelete("DeleteAuthor")]
	    public async Task<IActionResult> DeleteAuthor(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _authorManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
	    }
	}
}