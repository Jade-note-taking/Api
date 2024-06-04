using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JadeApi.Entities;

[Table("Notes")]
public class Note(Guid id, string name, string location, string contentPositionId)
{
    [Key]
    public Guid Id { get; set; } = id;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = name;

    [Required]
    public string Location { get; set; } = location;

    [Required]
    public string ContentPositionId { get; set; } = contentPositionId;
}
