
namespace Repositories.Interfaces
{
    public interface IRepositoryManger
    {
        ICourseRepository courseRepository { get; }
        void Save();
    }
}
