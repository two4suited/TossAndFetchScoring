using TossAndFetchScoring.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.TossAndFetchScoring_ApiService>("apiservice");

builder.AddNpmApp("react", "../TossAndFetchScoring.Web","dev")
    .WithReference(apiService)
    .WithEnvironmentPrefix("VITE_") 
    .WithEndpoint(5173,"http","frontend","PORT");
    
builder.Build().Run();
