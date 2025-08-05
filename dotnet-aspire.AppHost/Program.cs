var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var apiService = builder.AddProject<Projects.dotnet_aspire_ApiService>("apiservice");

builder.AddProject<Projects.dotnet_aspire_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
