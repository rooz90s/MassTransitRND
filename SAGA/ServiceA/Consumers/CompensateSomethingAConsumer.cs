using MassTransit;
using Shared.TestStateMachine;

namespace ServiceA.Consumers;

public class CompensateSomethingAConsumer : IConsumer<CompensateA>
{
    public async Task Consume(ConsumeContext<CompensateA> context)
    {
        Console.WriteLine(" ! >>>>>>>>  Compensating A ");

        await Task.CompletedTask;
    }
}