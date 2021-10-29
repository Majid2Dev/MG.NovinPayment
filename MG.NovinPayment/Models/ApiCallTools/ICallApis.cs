using System.Threading.Tasks;

namespace MG.NovinPayment.Models.ApiCallTools
{
    public interface ICallApis
    {
        Task<T> CallingApiAsync<T>(string apiUrl, object value) where T : new();
    }
}
