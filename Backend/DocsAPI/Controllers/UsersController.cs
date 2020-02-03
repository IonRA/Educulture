using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Docs.Domain.Interfaces.IManagers;
using Docs.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
	    public async Task<IActionResult> GetAllUsers()
	    {
            try
            {
                var users = await _userManager.GetAllAsync();

                if (users == null)
                    return NotFound();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpGet("GetUserById/{id}")]
	    public async Task<IActionResult> GetUserById(int id )
	    {
		    if (id <= 0)
		    {
			    return BadRequest("The given Id is not valid. Id must be greater than 0");
		    }
		    try
		    {
			    var user = await _userManager.GetAsync(x => x.Id == id);

			    if (user == null)
				    return NotFound();

			    return Ok(user);
		    }
		    catch (Exception ex)
		    {
			    return StatusCode(500, ex.Message);
		    }
	    }

	    [HttpPost("Login")]
	    public async Task<IActionResult> Login([FromBody]User user)
	    {
		    
		    try
		    {
			    var _user = await _userManager.GetAsync(x => x.Username == user.Username && x.Password == user.Password);

			    if (_user == null)
				    return NotFound();

			    return Ok(_user);
		    }
		    catch (Exception ex)
		    {
			    return StatusCode(500, ex.Message);  
		    }
	    }


        [HttpPost("CreateUser")]
	    
	    public async Task<IActionResult> CreateUser([FromBody]User user)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                
                var _user = await _userManager.CreateAsync(user);

                
                return Ok(_user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpPut("UpdateUser")]
	  
	    public async Task<IActionResult> UpdateUser([FromBody]User user)
	    {
            if (ModelState.IsValid == false)
                return BadRequest("Invalid data");

            try
            {
                var updatedUser = await _userManager.UpdateAsync(user);

                if (updatedUser == null)
                    return NotFound();

                
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

	    [HttpDelete("DeleteUser")]
	    public async Task<IActionResult> DeleteUser(int id)
	    {
            if (id <= 0)
                return BadRequest("Not a valid id!");

            try
            {
                await _userManager.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
	}
}