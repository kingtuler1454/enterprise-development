using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class UserDto
{
    /// <summary>
    /// Номер телефона пользователя.
    /// </summary>
    [Required]
    [Phone]
    public required string Phone { get; set; }

    /// <summary>
    /// Полное имя пользователя.
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string FullName { get; set; }
}
