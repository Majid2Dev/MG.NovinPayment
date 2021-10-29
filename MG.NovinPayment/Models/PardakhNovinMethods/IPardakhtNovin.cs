using MG.NovinPayment.Models.PardakhtNovin;
using System.Threading.Tasks;

namespace MG.NovinPayment.Models.PardakhNovinMethods
{
    public interface IPardakhtNovin
    {

        Task<RequestResultLogin> LoginAsync(string userName = "", string password = "", string apiUrl = "");
        PardakhtNovinParams.PardakhtNovinWSContext FillWSContext(string sessionId, string userName, string password);
         PardakhtNovinParams.PardakhtNovinRequestParam FillRequestParam(PardakhtNovinParams.PardakhtNovinWSContext wsContext,
             long price, string reserveNum, string goodsReferenceId, string productId,
             string terminalId, string redirectUrl, string merchantGoodReferenceId, string merchantData);
        Task<RequestGenerateTreanscationDataToSignResult>
            GenerateTreanscationDataToSignAsync(PardakhtNovinParams.PardakhtNovinRequestParam request,
            string apiUrl);

        PardakhtNovinParams.PardakhtNovinGenerateSignedDataToken FillGenerateSignedDataToken(PardakhtNovinParams.PardakhtNovinWSContext wsContext,
           RequestGenerateTreanscationDataToSignResult generateTreanscationDataToSigin);

        Task<RequestPardakhtNovinGenerateSignedDataTokenResult> GenerateSignedDataTokenAsync(PardakhtNovinParams.PardakhtNovinGenerateSignedDataToken signedDataToken, string apiUrl);

        Task<RequestPardakhtNovinLogoutResult> LogOut(PardakhtNovinParams.PardakhtNovinLogout sessionId, string apiUrl);

        Task<RequestPardakhtNovinVerifyTransactionReult> VerifyTransaction
            (PardakhtNovinParams.PardakhtNovinVerifyTransaction request, string apiUrl);
    }
}
