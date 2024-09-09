using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_configuration.Models;

[Table("RabbitMqExchanges")]
[PrimaryKey(nameof(RabbitMqExchangeModel.Exchange), nameof(RabbitMqExchangeModel.Queue))]
public record RabbitMqExchangeModel
{
    public required string Exchange { get; set; }

    public required string Queue { get; set; }

    public required string RoutingKey { get; set; }

    public required RabbitMqConfigModel RabbitMqConfigModel { get; set; }
}