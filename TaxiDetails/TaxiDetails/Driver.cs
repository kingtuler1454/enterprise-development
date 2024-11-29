using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDetails;
/// <summary>
/// class driver about info of driver
/// </summary>
[Table("drivers")]
public class Driver
{
    /// <summary>
    /// identificator
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// name of driver
    /// </summary>
    [Column("name")]
    public string? Name { get; set; }
    /// <summary>
    /// surname of driver
    /// </summary>
    [Column("surname")]
    public string? Surname { get; set; }
    /// <summary>
    /// patronymic of driver
    /// </summary>
    [Column("patronymic")]
    public string? Patronymic { get; set; }
    /// <summary>
    /// passport of driver
    /// </summary>
    [Column("passport")]
    public string? Passport { get; set; }
    /// <summary>
    /// address of driver
    /// </summary>
    [Column("address")]
    public string? Address { get; set; }
    /// <summary>
    /// phone of driver
    /// </summary>
    [Column("phone")]
    public string? Phone { get; set; }
    
}