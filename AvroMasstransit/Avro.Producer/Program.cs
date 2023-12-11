using Avro.Shared.Contracts;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(cnf =>
{
    cnf.UsingInMemory();
    
    cnf.AddRider(r =>
    {
        var schemaRegistry = new CachedSchemaRegistryClient(new SchemaRegistryConfig { Url = "http://172.22.3.52/:8081/" });
        
        r.AddProducer<EventX>("schimaTopic", (ctx, c) =>
        {
            c.SetValueSerializer(new AvroSerializer<EventX>(schemaRegistry));
        });
        
        
        r.UsingKafka((ctx, k) =>
        {
            k.Host("localhost:9092");
        });
        
    });
    
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();