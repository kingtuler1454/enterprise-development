using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class CarDto
{
    /// <summary>
    /// Номерной знак автомобиля.
    /// </summary>
    [Required]
    [StringLength(10)]
    public required string Plate { get; set; }

    /// <summary>
    /// Модель автомобиля.
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Model { get; set; }

    /// <summary>
    /// Цвет автомобиля.
    /// </summary>
    [Required]
    [StringLength(30)]
    public required string Color { get; set; }

    /// <summary>
    /// Идентификатор водителя, назначенного на автомобиль.
    /// </summary>
    public required int AssignedDriverId { get; set; }
}
