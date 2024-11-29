using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDetails;
/// <summary>
/// class about car
/// </summary>
[Table("cars")]
public class Car
{
    /// <summary>
    /// identificator
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// number of car
    /// </summary>
    [Column("plate")]
    public string? Plate { get; set; }
    /// <summary>
    /// model of car
    /// </summary>
    [Column("model")]
    public string? Model { get; set; }
    /// <summary>
    /// color
    /// </summary>
    [Column("color")]
    public string? Color { get; set; }
    /// <summary>
    /// relationship of driver
    /// </summary>
    [Column("assigned_driver")]
    [Required]
    public required Driver AssignedDriver { get; set; } 
}