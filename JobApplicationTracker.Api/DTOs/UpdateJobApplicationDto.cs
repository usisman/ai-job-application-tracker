using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Api.DTOs;

public class UpdateJobApplicationDto
{
    [Required]
    [MaxLength(100)]
    public string Company { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Position { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;
}