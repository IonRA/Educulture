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
    public class CoursesController : ControllerBase
    {
	    private ICourseManager _courseManager;

	    public CoursesController(ICourseManager courseManager)
	    {
		    _courseManager = courseManager;
	    }

	    [HttpGet("GetAllCourses")]
	    public async Task GetAllCourses()
	    {
		    await _courseManager.GetAllAsync();
	    }
	}
}