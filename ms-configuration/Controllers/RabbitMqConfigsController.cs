using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ms_configuration.Data;
using ms_configuration.Models;

namespace ms_configuration.Controllers;

public class RabbitMqConfigsController(ConfigurationDatabaseContext context) : ODataController
{
    private readonly ConfigurationDatabaseContext _context = context;

    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_context.RabbitMqConfigs);
    }

    [EnableQuery]
    public IActionResult Get([FromODataUri] Guid key)
    {
        var config = _context.RabbitMqConfigs.FirstOrDefault(c => c.Id == key);
        if (config == null)
        {
            return NotFound();
        }
        return Ok(config);
    }

    [HttpPost]
    public IActionResult Post([FromBody] RabbitMqConfigModel config)
    {
        _context.RabbitMqConfigs.Add(config);
        _context.SaveChanges();

        return Created(config);
    }
}
