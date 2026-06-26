namespace JobApplicationTracker.Api.DTOs;

public class UpdateJobApplicationDto
{
    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}