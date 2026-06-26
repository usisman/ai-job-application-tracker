using Microsoft.AspNetCore.Mvc;
using JobApplicationTracker.Api.Models;
using JobApplicationTracker.Api.DTOs;

namespace JobApplicationTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private static readonly List<JobApplication> Applications = new()
    {
        new JobApplication
        {
            Id = 1,
            Company = "Otoplan",
            Position = "Junior Full-Stack Developer",
            Status = "Applied"
        },
        new JobApplication
        {
            Id = 2,
            Company = "Leartes Studios",
            Position = "Backend Developer",
            Status = "Interview"
        },
        new JobApplication
        {
            Id = 3,
            Company = "OneSec",
            Position = "Embedded Software & Robotics Developer",
            Status = "Challenge"
        }
    };

    [HttpGet]
    public IActionResult GetApplications()
    {
        return Ok(Applications);
    }

    [HttpGet("{id}")]
    public IActionResult GetApplicationById(int id)
    {
        var application = Applications.FirstOrDefault(x => x.Id == id);

        if (application is null)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        return Ok(application);
    }

    [HttpPost]
    public IActionResult CreateApplication(CreateJobApplicationDto request)
    {
        var newApplication = new JobApplication
        {
            Id = Applications.Max(x => x.Id) + 1,
            Company = request.Company,
            Position = request.Position,
            Status = request.Status
        };

        Applications.Add(newApplication);

        return CreatedAtAction(
            nameof(GetApplicationById),
            new { id = newApplication.Id },
            newApplication
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateApplication(int id, UpdateJobApplicationDto request)
    {
        var application = Applications.FirstOrDefault(x => x.Id == id);

        if (application is null)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        application.Company = request.Company;
        application.Position = request.Position;
        application.Status = request.Status;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteApplication(int id)
    {
        var application = Applications.FirstOrDefault(x => x.Id == id);

        if (application is null)
        {
            return NotFound($"Application with id {id} was not found.");
        }

        Applications.Remove(application);

        return NoContent();
    }
}