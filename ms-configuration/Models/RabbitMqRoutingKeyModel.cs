using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_configuration.Models;

[Table("RabbitMqRoutingKeys")]
public record RabbitMqRoutingKeyModel
{
    [Key]
    public Guid Id { get; set; }

    public required string Exchange { get; set; }

    public required string Queue { get; set; }

    public required string RoutingKey { get; set; }
    
    public required string ActionName { get; set; }

    public required DateTime CreationDate { get; set; } = DateTime.UtcNow;
    
    public required bool Deleted { get; set; } = false;
}