namespace RefactorThis.Service.Framework
{
    public interface IApplicationServiceOutputBase
        
    {
        ResultErrors ResultErrors { get; }

        bool ResultSuccess { get; }
    }

}