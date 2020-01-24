using System.Threading.Tasks;

namespace DigitalLibrary.Utils.DiLibHttpClient
{
    public interface IDiLibHttpClient
    {
        Task<T> PostAsync<T>(T payload, string url);

        Task DeleteAsync<T>(T payload, string url);

        Task<T> GetAsync<T>(string url);

        Task<T> PutAsync<T>(T payload, string url);
    }
}