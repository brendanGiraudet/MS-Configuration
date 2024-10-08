﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ms_configuration.Models;

[Table("RabbitMqConfigs")]
public record RabbitMqConfigModel
{
    [Key]
    public Guid Id { get; set; }
    
    public required string Hostname { get; set; }
    
    public required int Port { get; set; }
    
    public required string Username { get; set; }
    
    public required string Password { get; set; }

    public required DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public required bool Deleted { get; set; } = false;
}
