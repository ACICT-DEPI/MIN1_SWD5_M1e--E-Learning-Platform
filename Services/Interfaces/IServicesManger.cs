namespace Services.Interfaces
{
    public interface IServicesManger
    {
        ICourseServices courseServices { get; }
        IModuleServices moduleServices { get; }
        ILessonService lessonServices { get; }
        IUploadFileService uploadFileServices { get; }
        IMaterialServices materialServices { get; }
        IProgressServices progressServices { get; }
        INoteServices noteServices { get; }
    }
}
