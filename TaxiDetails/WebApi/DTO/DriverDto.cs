using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class DriverDto
{
    /// <summary>
    /// name driver
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// surname driver
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Surname { get; set; }

    /// <summary>
    ///patronymic driver
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Patronymic { get; set; }

    /// <summary>
    /// passport information
    /// </summary>
    [Required]
    [StringLength(20)]
    public required string Passport { get; set; }

    /// <summary>
    /// addres
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string Address { get; set; }

    /// <summary>
    /// number of phone
    /// </summary>
    [Required]
    [Phone]
    public required string Phone { get; set; }
}
