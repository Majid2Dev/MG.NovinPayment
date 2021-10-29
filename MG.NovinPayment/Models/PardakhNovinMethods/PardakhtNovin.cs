using MG.NovinPayment.Models.ApiCallTools;
using MG.NovinPayment.Models.PardakhtNovin;
using System;
using System.Text;
using System.Threading.Tasks;
namespace MG.NovinPayment.Models.PardakhNovinMethods
{
    public class PardakhtNovin : IPardakhtNovin
    {
        const string successText = "erSucceed";
        private readonly ICallApis _callApis;
        public PardakhtNovin(ICallApis callApis)
        {
            _callApis = callApis;
        }
        public async Task<RequestResultLogin> LoginAsync(string userName = "", string password = "", string apiUrl = "")
        {

            var loginParam = new PardakhtNovinParams.PardakhtNovinLogin
            {
                UserName = userName,
                Password = password
            };
            var loginResult = await _callApis.CallingApiAsync<PardakhtNovinParams.PardakhtNovinLoginResult>(apiUrl, loginParam);
            RequestResultLogin result = null;
            if (loginResult.Result.Equals(successText))
            {
                result = new RequestResultLogin
                {
                    IsSuccess = true,
                    SessionId = loginResult.SessionId,
                    Descriptions = loginResult.Result,
                };
            }
            else
            {
                result = new RequestResultLogin
                {
                    IsSuccess = false,
                    Descriptions = loginResult.Result,
                    SessionId = "NULL"
                };
            }
            return result;








        }
        public PardakhtNovinParams.PardakhtNovinWSContext FillWSContext(string sessionId, string userName, string password)
        {

            var wsContext = new PardakhtNovinParams.PardakhtNovinWSContext
            {
                SessionId = sessionId,
                UserId = userName,
                Password = password
            };
            return wsContext;
        }
        public PardakhtNovinParams.PardakhtNovinRequestParam FillRequestParam(PardakhtNovinParams.PardakhtNovinWSContext wsContext,
            long price, string reserveNum, string goodsReferenceId, string productId,
            string terminalId, string redirectUrl, string merchantGoodReferenceId, string merchantData)
        {
            var requestParam = new PardakhtNovinParams.PardakhtNovinRequestParam();
            requestParam.WSContext = wsContext;

            requestParam.TransType = PardakhtNovinParams.PardakhtNovinEnTransType.enGoods;

            requestParam.ReserveNum = reserveNum;
            requestParam.TerminalId = terminalId;
            requestParam.Amount = Convert.ToDecimal(price);
            requestParam.RedirectUrl = redirectUrl;
            requestParam.GoodsReferenceID = goodsReferenceId;
            requestParam.MerchatGoodReferenceID = merchantGoodReferenceId;
            requestParam.ProductId = productId;
            requestParam.merchantData = merchantData;





            return requestParam;
        }
        public async Task<RequestGenerateTreanscationDataToSignResult>
            GenerateTreanscationDataToSignAsync(PardakhtNovinParams.PardakhtNovinRequestParam request,
            string apiUrl)

        {

            var payResult = await _callApis.CallingApiAsync<PardakhtNovinParams.PardakhtNovinGenerateTreanscationDataToSign>(apiUrl, request);
            RequestGenerateTreanscationDataToSignResult Result = null;
            if (payResult.Result.Equals(successText))
            {
                Result = new RequestGenerateTreanscationDataToSignResult
                {
                    DataToSign = payResult.DataToSign,
                    IsSuccess = true,
                    UniqueId = payResult.UniqueId,
                    Descriptions = payResult.Result
                };
            }
            else
            {
                Result = new RequestGenerateTreanscationDataToSignResult
                {
                    DataToSign = payResult.DataToSign,
                    IsSuccess = false,
                    UniqueId = payResult.UniqueId,
                    Descriptions = payResult.Result

                };
            }
            return Result;
        }
        public PardakhtNovinParams.PardakhtNovinGenerateSignedDataToken FillGenerateSignedDataToken(PardakhtNovinParams.PardakhtNovinWSContext wsContext,
           RequestGenerateTreanscationDataToSignResult generateTreanscationDataToSigin)
        {
            var GetByte = Encoding.UTF8.GetBytes(generateTreanscationDataToSigin.DataToSign);
            var base64 = Convert.ToBase64String(GetByte);
            var param = new PardakhtNovinParams.PardakhtNovinGenerateSignedDataToken()
            {
                WSContext = wsContext,
                UniqueId = generateTreanscationDataToSigin.UniqueId,
                Signature = base64
            };
            return param;
        }

        public async Task<RequestPardakhtNovinGenerateSignedDataTokenResult> GenerateSignedDataTokenAsync(PardakhtNovinParams.PardakhtNovinGenerateSignedDataToken signedDataToken, string apiUrl)
        {

            var tokenResult = await _callApis.CallingApiAsync<PardakhtNovinParams.PardakhtNovinGenerateSignedDataTokenResult>(
               apiUrl, signedDataToken);
            RequestPardakhtNovinGenerateSignedDataTokenResult Result = null;
            if (tokenResult.Result.Equals(successText))
            {
                Result = new RequestPardakhtNovinGenerateSignedDataTokenResult
                {
                    IsSuccess = true,
                    ExpirationDate = tokenResult.ExpirationDate,
                    Token = tokenResult.Token,
                    Descriptions = tokenResult.Result,
                };
            }
            else
            {
                Result = new RequestPardakhtNovinGenerateSignedDataTokenResult
                {
                    IsSuccess = false,
                    ExpirationDate = "NULL",
                    Token = "NULL",
                    Descriptions = tokenResult.Result,

                };
            }
            return Result;
        }
        public static string CreatePaymetnUrl(string token, string paymentUrl)
        {

            paymentUrl = paymentUrl.Replace("{TOKEN}", token);
            return paymentUrl;
        }

        public async Task<RequestPardakhtNovinLogoutResult> LogOut(PardakhtNovinParams.PardakhtNovinLogout sessionId, string apiUrl)
        {
            var Result = await _callApis.CallingApiAsync<PardakhtNovinParams.PardakhtNovinLogoutResult>(apiUrl, sessionId);
            RequestPardakhtNovinLogoutResult logoutResult = null;
            if (Result.Result.Equals(successText))
            {
                logoutResult = new RequestPardakhtNovinLogoutResult
                {
                    IsSuccess = true,
                    SessionId = Result.SessionId,
                    Descriptions = Result.Result
                };
            }
            else
            {
                logoutResult = new RequestPardakhtNovinLogoutResult
                {
                    SessionId = "Null",
                    IsSuccess = false,
                    Descriptions = Result.Result

                };
            }
            return logoutResult;


        }
        public async Task<RequestPardakhtNovinVerifyTransactionReult> VerifyTransaction
            (PardakhtNovinParams.PardakhtNovinVerifyTransaction request, string apiUrl)
        {
            var Result = await _callApis.CallingApiAsync<PardakhtNovinParams.PardakhtNovinVerifyTransactionReult>
                (apiUrl, request);
            RequestPardakhtNovinVerifyTransactionReult VerfiyResult = null;
            if (Result.Result.Equals(successText))
            {
                VerfiyResult = new RequestPardakhtNovinVerifyTransactionReult
                {
                    IsSuccess = true
                };
            }
            else
            {
                VerfiyResult = new RequestPardakhtNovinVerifyTransactionReult
                {
                    IsSuccess = false
                };
            }
            return VerfiyResult;
        }

    }
}