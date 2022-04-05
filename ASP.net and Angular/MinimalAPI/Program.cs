using Microsoft.EntityFrameworkCore;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContainerContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IContainerService, ContainerService>();
var app = builder.Build();


app.MapGet("/container", async (IContainerService containerService) => await containerService.GetContainer());

app.MapGet("/container/{id}", async (int id, IContainerService containerService) => await containerService.GetContainerById(id));

app.MapPost("/container", async (ContainerRequest containerRequest, IContainerService containerService) => await containerService.CreateContainer(containerRequest));

app.MapPut("/container/{id}", async (int id, ContainerRequest containerRequest, IContainerService containerService) => await containerService.UpdateContainer(id, containerRequest));

app.MapDelete("/container/{id}", async (int id, IContainerService containerService) => await containerService.DeleteContainer(id));

app.Run();


