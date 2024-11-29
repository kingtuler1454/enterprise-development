using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDetails;
/// <summary>
/// class User about info of users
/// </summary>
[Table("users")]
public class User
{   /// <summary>
    /// identificator
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Phone
    /// </summary>
    [Column("phone")]
    public string? Phone { get; set; }
    /// <summary>
    /// Fullname
    /// </summary>
    [Column("full_name")]
    public string? FullName { get; set; }
}