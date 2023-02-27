using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;

namespace StarGate.Controllers;

/// <summary>
///  A requests controller.
/// </summary>
[Route("api")]
[ApiController]
public class RequestsController : ControllerBase
{
	/// <summary>
	/// A request manager.
	/// </summary>
	private IRequestManager _requestManager;

	/// <summary>
	///  Gets a request.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>IActionResult</returns>
	[HttpGet("requests/{code}")]
	public IActionResult GetRequest(string code)
	{
		RequestDto? request = _requestManager.GetRequestByCode(code);

		if (request is null)
			return Problem(title: "Error", detail: "Request with such code isn't in the database.", statusCode: 404);

		return Ok();
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="requestManager">A request manager</param>
	public RequestsController(IRequestManager requestManager) => _requestManager = requestManager;
}