namespace Services.Interfaces
{
    public interface IServicesManger
    {
        ICourseServices courseServices { get; }
        IModuleServices moduleServices { get; }
    }
}
