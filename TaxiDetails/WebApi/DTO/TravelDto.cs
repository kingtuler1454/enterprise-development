using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO;

public class TravelDto
{
    /// <summary>
    /// from
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// to
    /// </summary>
    [Required]
    [StringLength(100)]
    public required string DestinationPoint { get; set; }

    /// <summary>
    /// date of travel
    /// </summary>
    [Required]
    public required DateTime TripDate { get; set; }

    /// <summary>
    /// time of travel
    /// </summary>
    [Required]
    public required TimeSpan TravelTime { get; set; }

    /// <summary>
    /// cost
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue)]
    public required decimal Cost { get; set; }

    /// <summary>
    /// identificator of car
    /// </summary>
    public required int AssignedCarId { get; set; }

    /// <summary>
    /// identificator of client
    /// </summary>
    public required int ClientId { get; set; }
}
