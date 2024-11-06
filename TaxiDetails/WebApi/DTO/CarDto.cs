using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class CarDto
{
    /// <summary>
    /// number list of car
    /// </summary>
    [Required]
    [StringLength(10)]
    public required string Plate { get; set; }

    /// <summary>
    /// model car
    /// </summary>
    [Required]
    [StringLength(50)]
    public required string Model { get; set; }

    /// <summary>
    /// color
    /// </summary>
    [Required]
    [StringLength(30)]
    public required string Color { get; set; }

    /// <summary>
    /// identificator of driver
    /// </summary>
    public required int AssignedDriverId { get; set; }
}
