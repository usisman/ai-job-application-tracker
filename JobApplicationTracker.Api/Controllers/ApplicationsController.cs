using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.DTOs;
using JobApplicationTracker.Api.Models;

namespace JobApplicationTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ApplicationsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetApplications()
    {
        var applications = await _context.JobApplications.ToListAsync();

        return Ok(applications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationById(int id)
    {
        var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);

        if (application is null)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        return Ok(application);
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication(CreateJobApplicationDto request)
    {
        var newApplication = new JobApplication
        {
            Company = request.Company,
            Position = request.Position,
            Status = request.Status
        };

        _context.JobApplications.Add(newApplication);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetApplicationById),
            new { id = newApplication.Id },
            newApplication
        );
    }
}