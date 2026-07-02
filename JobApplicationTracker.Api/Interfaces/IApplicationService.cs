using JobApplicationTracker.Api.DTOs;
using JobApplicationTracker.Api.Models;

namespace JobApplicationTracker.Api.Interfaces;

public interface IApplicationService
{
    Task<List<JobApplication>> GetAllAsync();
    Task<JobApplication?> GetByIdAsync(int id);
    Task<JobApplication> CreateAsync(CreateJobApplicationDto request);
    Task<bool> UpdateAsync(int id, UpdateJobApplicationDto request);
    Task<bool> DeleteAsync(int id);
}