using JobApplicationTracker.Api.Data;
using JobApplicationTracker.Api.DTOs;
using JobApplicationTracker.Api.Interfaces;
using JobApplicationTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationTracker.Api.Services;

public class ApplicationService : IApplicationService
{
    private readonly AppDbContext _context;

    public ApplicationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<JobApplication>> GetAllAsync()
    {
        return await _context.JobApplications.ToListAsync();
    }

    public async Task<JobApplication?> GetByIdAsync(int id)
    {
        return await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<JobApplication> CreateAsync(CreateJobApplicationDto request)
    {
        var newApplication = new JobApplication
        {
            Company = request.Company,
            Position = request.Position,
            Status = request.Status
        };

        _context.JobApplications.Add(newApplication);
        await _context.SaveChangesAsync();

        return newApplication;
    }

    public async Task<bool> UpdateAsync(int id, UpdateJobApplicationDto request)
    {
        var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);

        if (application is null)
        {
            return false;
        }

        application.Company = request.Company;
        application.Position = request.Position;
        application.Status = request.Status;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);

        if (application is null)
        {
            return false;
        }

        _context.JobApplications.Remove(application);
        await _context.SaveChangesAsync();

        return true;
    }
}