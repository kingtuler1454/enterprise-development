using System.ComponentModel.DataAnnotations;

namespace TaxiDetails.WebApi.DTO;

/// <summary>
/// Data transfer object for user information.
/// </summary>
public class UserDto
{
    /// <summary>
    /// number phone
    /// </summary>
    [Required]
    [Phone]
    public required string Phone { get; set; }

    /// <summary>
    /// fullname client
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string FullName { get; set; }
}
