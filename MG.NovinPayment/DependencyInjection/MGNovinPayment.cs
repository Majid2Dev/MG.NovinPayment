using MG.NovinPayment.Models.ApiCallTools;
using MG.NovinPayment.Models.PardakhNovinMethods;
using Microsoft.Extensions.DependencyInjection;
namespace MG.NovinPayment.DpenedenciInjection
{
    public static class MGNovinPayment
    {
        public static IServiceCollection AddMGNovinPayment(this IServiceCollection service)
        {

            //register ApiCallTools
            service.AddTransient<ICallApis, CallApis>();

            //Register PaymentMethods

            service.AddTransient<IPardakhtNovin, PardakhtNovin>();

            return service;
        }
    }
}
