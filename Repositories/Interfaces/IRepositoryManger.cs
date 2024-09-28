
namespace Repositories.Interfaces
{
    public interface IRepositoryManger
    {
        ICourseRepository courseRepository { get; }
        IModuleRepository moduleRepository { get; }
        Task Save();
    }
}
