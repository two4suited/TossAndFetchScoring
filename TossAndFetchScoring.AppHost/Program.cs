using Aspire.Hosting;
using TossAndFetchScoring.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.TossAndFetchScoring_ApiService>("apiservice");

builder.AddNpmApp("react", "../TossAndFetchScoring.Web","dev")
    .WithReference(apiService)
    .WithEnvironmentPrefix("VITE_") 
    .WithHttpEndpoint(targetPort:3001,env:"PORT");
    
builder.Build().Run();
