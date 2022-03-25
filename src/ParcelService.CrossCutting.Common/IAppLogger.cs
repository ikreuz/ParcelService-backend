namespace ParcelService.CrossCutting.Common
{
    public interface IAppLogger<T>
    {
        void LogInfomation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
