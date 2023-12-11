using MassTransit;
using Shared.TestStateMachine;

namespace ServiceB.Consumers;

public class CompensateBConsumer : IConsumer<CompensateB>
{
    public async Task Consume(ConsumeContext<CompensateB> context)
    {
        Console.WriteLine(" ! >>>>>>>>  Compensating B ");

        await Task.CompletedTask;
    }
}