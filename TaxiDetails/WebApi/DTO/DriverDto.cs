using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class DriverDto
{
    /// <summary>
    /// Имя водителя.
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// Фамилия водителя.
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Surname { get; set; }

    /// <summary>
    /// Отчество водителя.
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Patronymic { get; set; }

    /// <summary>
    /// Паспортные данные водителя.
    /// </summary>
    [Required]
    [StringLength(20)]
    public required string Passport { get; set; }

    /// <summary>
    /// Адрес водителя.
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string Address { get; set; }

    /// <summary>
    /// Номер телефона водителя.
    /// </summary>
    [Required]
    [Phone]
    public required string Phone { get; set; }
}
