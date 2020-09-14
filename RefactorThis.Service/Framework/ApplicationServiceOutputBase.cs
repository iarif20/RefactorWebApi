namespace RefactorThis.Service.Framework
{
    public class ApplicationServiceOutputBase : IApplicationServiceOutputBase
    {
        public ApplicationServiceOutputBase()
        {
            ResultErrors = new ResultErrors();
        }

        public ResultErrors ResultErrors { get; }

        public bool ResultSuccess => ResultErrors.Messages.Count == 0;
    }
}