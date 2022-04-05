namespace MinimalAPI
{
    public interface IContainerService
    {
        Task<IResult> GetContainer();

        Task<IResult> GetContainerById(int id);
        Task<IResult> CreateContainer(ContainerRequest article);
        Task<IResult> UpdateContainer(int id, ContainerRequest article);
        Task<IResult> DeleteContainer(int id);
    }
}
