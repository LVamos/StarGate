using Microsoft.AspNetCore.Mvc;

using StarGate.Business.Interfaces;
using StarGate.Business.Models;
using StarGate.Data.Models;

namespace StarGate.Controllers;

/// <summary>
///  A requests controller.
/// </summary>
[Route("api")]
[ApiController]
public class RequestsController : ControllerBase
{
	/// <summary>
	///  Deletes a request.
	/// </summary>
	/// <param name="code">A short string identifying the request to be deleted</param>
	/// <returns>IActionResult</returns>
	[HttpDelete("requests")]
	public IActionResult DeleteRequest(string code)
	{
		if (_requestManager.DeleteRequest(code))
			return Ok();

		return Problem(title: "Error", detail: "Unable to delete the request", statusCode: 500);
	}

	/// <summary>
	/// Adds a request into the queue.
	/// </summary>
	/// <param name="code">A short string identifying the request</param>
	/// <param name="type">Specifies type of the request</param>
	/// <param name="planetCode">Code of a planet to explore</param>
	/// <returns>IActionResult</returns>
	[HttpPost("requests")]
	public IActionResult AddRequest(string code, RequestType type, string planetCode = "")
	{
		// Store the request.
		RequestDto? request = _requestManager.AddRequest(code, type, planetCode);

		if (request is null)
			return Problem(title: "Error", detail: "The request could not be added.", statusCode: 500);

		return CreatedAtAction(nameof(GetRequest), new { code = request.Code }, request);
	}


	/// <summary>
	///  Gets all requests.
	/// </summary>
	/// <returns>ienumeration of requests</returns>
	[HttpGet("requests")]
	public IEnumerable<RequestDto> GetRequests() => _requestManager.GetAllRequests();

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