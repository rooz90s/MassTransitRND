using Avro.Shared.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Avro.Producer.Controllers;

[ApiController]
[Route("[controller]")]
public class AvroProducerController : ControllerBase
{

    private readonly ITopicProducer<EventX> _producer;

    public AvroProducerController(ITopicProducer<EventX> producer)
    {
        _producer = producer;
    }

    [HttpPost("ProduceA")]
    public async Task<IActionResult> ProduceA()
    {
        var d = DateTime.Now;
        
        await _producer.Produce(new EventX
        {
            Title = $"Events",
            Event = new EventA
            {
                DataA = $"This Event A in {DateTime.Now}"
            }
        });

        return Ok(d);
    }
}