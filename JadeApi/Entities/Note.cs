using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JadeApi.Entities;

[Table("Notes")]
public class Note(Guid id, string name, string location, string cosmosId)
{
    [Key]
    public Guid Id { get; set; } = id;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = name;

    [Required]
    public string Location { get; set; } = location;

    [Required]
    public string CosmosId { get; set; } = cosmosId;
}

record CosmosNote(
    string id,
    string UserId, // for combined index with content (future thing probably, to improve search latency)
    string Content
);
