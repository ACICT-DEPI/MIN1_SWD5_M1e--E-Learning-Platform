
namespace Repositories.Interfaces
{
    public interface IRepositoryManger
    {
        ICourseRepository courseRepository { get; }
        IModuleRepository moduleRepository { get; }
        ILessonRepository lessonRepository { get; }
        IMaterialRepository materialRepository { get; }
        IProgressRepository progressRepository { get; }
        INoteRepository noteRepository { get; }
        IPaymentRepository paymentRepository { get; }
        Task Save();
    }
}
