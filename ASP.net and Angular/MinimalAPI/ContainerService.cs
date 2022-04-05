using Microsoft.EntityFrameworkCore;

namespace MinimalAPI
{
    public class ContainerService : IContainerService
    {
        public readonly ContainerContext _context;

        public ContainerService(ContainerContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetContainer()
        {
            return Results.Ok(await _context.Containers.ToListAsync());

        }
        public async Task<IResult> GetContainerById(int id)
        {
            var article = await _context.Containers.FindAsync(id);
            return article != null ? Results.Ok(article) : Results.NotFound();

        }

        public async Task<IResult> CreateContainer(ContainerRequest containerRequest)
        {
            var createdContainer = _context.Containers.Add(new container
            {
                ContainerID = containerRequest.ContainerID ?? String.Empty,
                ContainerType = containerRequest.ContainerType ?? String.Empty,
            });

            await _context.SaveChangesAsync();

            return Results.Created($"/articles/" + $"{createdContainer.Entity.Id}", createdContainer.Entity);
        }
        public async Task<IResult> UpdateContainer(int id, ContainerRequest container)
        {
            var ContainerToUpdate = await _context.Containers.FindAsync(id);

            if (ContainerToUpdate != null)
            {
                return Results.NotFound();
            }

            if (container.ContainerID != null)
            {
                ContainerToUpdate.ContainerID = container.ContainerID;
            }
            if (container.ContainerType != null)
            {
                ContainerToUpdate.ContainerType = container.ContainerType;
            }

            await _context.SaveChangesAsync();

            return Results.Ok(ContainerToUpdate);
        }
        public async Task<IResult> DeleteContainer(int id)
        {
            var ContainerToDelete = await _context.Containers.FindAsync(id);
            if (ContainerToDelete == null)
            {
                return Results.NotFound();
            }
            _context.Containers.Remove(ContainerToDelete);

            await _context.SaveChangesAsync();
            return Results.Ok(ContainerToDelete);
        }
    }

}
