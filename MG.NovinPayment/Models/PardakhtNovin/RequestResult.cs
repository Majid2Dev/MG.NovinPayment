using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.NovinPayment.Models.PardakhtNovin
{
    public class RequestResultLogin
    {
        public bool IsSuccess { get; set; }
        public string SessionId { get; set; }
        public string Descriptions { get; set; }

    }
    public class RequestGenerateTreanscationDataToSignResult
    {
        public bool IsSuccess { get; set; }
        public string DataToSign { get; set; }
        public string UniqueId { get; set; }
        public string Descriptions { get; set; }

    }
    public class RequestPardakhtNovinGenerateSignedDataTokenResult
    {
        public bool IsSuccess { get; set; }
        public string ExpirationDate { get; set; }
        public string Token { get; set; }
        public string Descriptions { get; set; }

    }
    public class RequestPardakhtNovinLogoutResult
    {
        public string SessionId { get; set; }
        public bool IsSuccess { get; set; }
        public string Descriptions { get; set; }

    }
    public class RequestPardakhtNovinVerifyTransactionReult
    {
        public bool IsSuccess { get; set; }
    }
}
