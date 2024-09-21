var builder = DistributedApplication.CreateBuilder(args);

builder.AddContainer("grafana", "grafana/grafana")
       .WithBindMount("../../../compose/grafana/config", "/etc/grafana", isReadOnly: true)
       .WithBindMount("../../../compose/grafana/dashboards", "/var/lib/grafana/dashboards", isReadOnly: true)
       .WithHttpEndpoint(port: 3000, targetPort: 3000, name: "http");

builder.AddContainer("prometheus", "prom/prometheus")
       .WithBindMount("../../../compose/prometheus", "/etc/prometheus", isReadOnly: true)
       .WithHttpEndpoint(port: 9090, targetPort: 9090);

var webApi = builder.AddProject<Projects.Server>("webapi");

builder.AddNpmApp("tmc-frontend", "../../apps/tmc-frontend", "dev")
    .WithReference(webApi)
    .WithHttpEndpoint(port: 3010, env: "PORT")
    .PublishAsDockerFile();

await using var app = builder.Build();

await app.RunAsync();
