namespace DiLibHttpClient
{
    using System.Threading.Tasks;

    public interface IDiLibHttpClient
    {
        Task<T> Post<T>(T payload, string url);

        Task Delete<T>(T payload, string url);

        Task<T> Get<T>(string url);

        Task<T> Put<T>(T payload, string url);
    }
}