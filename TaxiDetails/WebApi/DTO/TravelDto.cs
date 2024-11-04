using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class TravelDto
{
    /// <summary>
    /// Точка отправления.
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Точка назначения.
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string DestinationPoint { get; set; }

    /// <summary>
    /// Дата поездки.
    /// </summary>
    [Required]
    public required DateTime TripDate { get; set; }

    /// <summary>
    /// Время поездки.
    /// </summary>
    [Required]
    public required TimeSpan TravelTime { get; set; }

    /// <summary>
    /// Стоимость поездки.
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue)]
    public required decimal Cost { get; set; }

    /// <summary>
    /// Идентификатор автомобиля, назначенного для поездки.
    /// </summary>
    public required int AssignedCarId { get; set; }

    /// <summary>
    /// Идентификатор клиента (пользователя), заказавшего поездку.
    /// </summary>
    public required int ClientId { get; set; }
}
