var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");
var rabbit = builder.AddRabbitMQContainer("rabbit")
    .WithEnvironment("RABBITMQ_DEFAULT_USER", "myuser")
    .WithEnvironment("RABBITMQ_DEFAULT_PASS", "mypassword");


var apiService = builder.AddProject<Projects.dotnet_aspire_ApiService>("apiservice");

builder.AddProject<Projects.dotnet_aspire_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService)
    .WithReference(rabbit);

builder.Build().Run();
