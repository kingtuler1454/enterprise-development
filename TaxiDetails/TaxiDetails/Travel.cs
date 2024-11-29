using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDetails;
/// <summary>
/// class Travel about info of trips
/// </summary>
[Table("travels")]
public class Travel{
    /// <summary>
    /// identificator
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// from
    /// </summary>
    [Column("departure_point")]
    public string? DeparturePoint { get; set; }
    /// <summary>
    /// to
    /// </summary>
    [Column("destination_point")]
    public string? DestinationPoint { get; set; }
    /// <summary>
    /// date of trip
    /// </summary>
    [Column("trip_date")]
    public DateTime? TripDate { get; set; }
    /// <summary>
    /// time of trip
    /// </summary>
    [Column("trip_time")]
    public TimeSpan? TravelTime { get; set; }
    /// <summary>
    /// cost
    /// </summary>
    [Column("cost")]
    public decimal? Cost { get; set; }
    /// <summary>
    /// Relationship with car
    /// </summary>
    [Column("assigned_car")]
    [Required]
    public required Car AssignedCar { get; set; }
    /// <summary>
    /// Relationship with user
    /// </summary>
    [Column("client")]
    [Required]
    public required User Client { get; set; }
}