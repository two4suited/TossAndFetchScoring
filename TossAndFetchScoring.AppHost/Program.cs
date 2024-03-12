var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.TossAndFetchScoring_ApiService>("apiservice");

builder.AddNpmApp("react", "../TossAndFetchScoring.Web")
    .WithReference(apiService)
    .WithEndpoint(containerPort: 3001, scheme: "http", env: "PORT")
    .AsDockerfileInManifest();


builder.Build().Run();
