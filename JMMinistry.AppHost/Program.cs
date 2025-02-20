var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.JMMinistry_API>("jmministry-api");

builder.AddProject<Projects.JMMinistry_Web>("jmministry-web")
    .WithExternalHttpEndpoints()
    .WithReference(api);

builder.Build().Run();
