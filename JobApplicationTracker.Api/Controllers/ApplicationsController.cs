using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.Api.DTOs;
using JobApplicationTracker.Api.Interfaces;

namespace JobApplicationTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetApplications()
    {
        var applications = await _applicationService.GetAllAsync();

        return Ok(applications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationById(int id)
    {
        var application = await _applicationService.GetByIdAsync(id);

        if (application is null)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        return Ok(application);
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication(CreateJobApplicationDto request)
    {
        var newApplication = await _applicationService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetApplicationById),
            new { id = newApplication.Id },
            newApplication
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApplication(int id, UpdateJobApplicationDto request)
    {
        var result = await _applicationService.UpdateAsync(id, request);

        if (!result)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var result = await _applicationService.DeleteAsync(id);

        if (!result)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        return NoContent();
    }
}