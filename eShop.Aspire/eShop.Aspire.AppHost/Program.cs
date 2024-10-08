var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.eShop_Api>("eshop-api");

builder.Build().Run();
