using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ms_configuration.Data;
using ms_configuration.Models;

namespace ms_configuration.Controllers;

public class RabbitMqRoutingKeysController(ConfigurationDatabaseContext context) : ODataController
{
    private readonly ConfigurationDatabaseContext _context = context;

    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_context.RabbitMqRoutingKeys);
    }

    [EnableQuery]
    public IActionResult Get([FromODataUri] Guid key)
    {
        var config = _context.RabbitMqRoutingKeys.FirstOrDefault(c => c.Id == key);
        if (config == null)
        {
            return NotFound();
        }
        return Ok(config);
    }

    [HttpPost]
    public IActionResult Post([FromBody] RabbitMqRoutingKeyModel config)
    {
        _context.RabbitMqRoutingKeys.Add(config);
        _context.SaveChanges();

        return Created(config);
    }
}
