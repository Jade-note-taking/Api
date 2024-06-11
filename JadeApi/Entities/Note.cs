using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JadeApi.Entities;

[Table("Note")]
public class Note
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public string? Location { get; set; }

    [Required]
    public string CosmosId { get; set; }
}

record CosmosNote(
    string id,
    string Content
)
{
}
