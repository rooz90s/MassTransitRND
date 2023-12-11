using MassTransit;
using Shared.TestStateMachine;

namespace ServiceC.Consumers;

public class CompensateCConsumer : IConsumer<CompensateC>
{
    public async Task Consume(ConsumeContext<CompensateC> context)
    {
        Console.WriteLine(" ! >>>>>>>>  Compensating C ");

        await Task.CompletedTask;
    }
}