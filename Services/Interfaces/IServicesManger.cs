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
        IPaymentServices paymentServices { get; }
        IStripeServices stripeServices { get; }
        IPayPalServices payPalServices { get; }
        INoteServices noteServices { get; }
        IEnrollmentServices enrollmentServices { get; }
        IAnouncmentServices anouncmentServices { get; }
        IQuestionServices questionServices { get; }
        IAnswerServices answerServices { get; }
    }
}
