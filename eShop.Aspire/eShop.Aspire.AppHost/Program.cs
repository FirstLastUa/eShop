var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithDataVolume("eShopVolume")
    .WithPgAdmin();
var eShopDb = postgres.AddDatabase("eShopDb");

builder.AddProject<Projects.eShop_Api>("eshop-api")
    .WithReference(eShopDb);

builder.Build().Run();
