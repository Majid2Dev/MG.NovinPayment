
using System;

namespace MG.NovinPayment.Models.PardakhtNovin
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PardakhtNovinParams
    {
        public class PardakhtNovinLogin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }



        public class PardakhtNovinLoginResult
        {
            public string Result { get; set; }
            public string SessionId { get; set; }
        }


        public class PardakhtNovinWSContext
        {
            public string SessionId { get; set; }
            public string UserId { get; set; }
            public string Password { get; set; }
        }
        public class PardakhtNovinGenerateTreanscationDataToSign
        {
            public string Result { get; set; }
            public string DataToSign { get; set; }
            public string UniqueId { get; set; }
        }
        public class PardakhtNovinRequestParam
        {
            public PardakhtNovinWSContext WSContext { get; set; }
            public PardakhtNovinEnTransType TransType { get; set; }
            public string ReserveNum { get; set; }
            public string TerminalId { get; set; }
            public decimal Amount { get; set; }
            public string RedirectUrl { get; set; }
            public string GoodsReferenceID { get; set; }
            public string MerchatGoodReferenceID { get; set; }
            public string ProductId { get; set; }
            public string merchantData { get; set; }




        }

        public class PardakhtNovinGenerateSignedDataToken
        {
            public PardakhtNovinWSContext WSContext { get; set; }
            public string Signature { get; set; }
            public string UniqueId { get; set; }
        }




        public class PardakhtNovinGenerateSignedDataTokenResult
        {
            public string Result { get; set; }
            public string ExpirationDate { get; set; }
            public string Token { get; set; }
        }

        public class PardakhtNovinCallBackRequesntPayment
        {
            public string token { get; set; }
            public string State { get; set; }
            public string ResNum { get; set; }
            public string RefNum { get; set; }
            public string CustomerRefNum { get; set; }
            public string MID { get; set; }
            public string language { get; set; }
            public string CardHashPan { get; set; }
            public string CardMaskPan { get; set; }
            public string redirectURL { get; set; }
            public string goodReferenceId { get; set; }
            public string merchantData { get; set; }
            //public string TraceNo { get; set; }
            //public string transactionAmount { get; set; }

        }

        public class PardakhtNovinLogout
        {
            public string SessionId { get; set; }
        }
        public class PardakhtNovinLogoutResult
        {
            public string SessionId { get; set; }
            public string Result { get; set; }

            public static implicit operator PardakhtNovinLogoutResult(RequestPardakhtNovinLogoutResult v)
            {
                throw new NotImplementedException();
            }
        }
        public class PardakhtNovinVerifyTransaction
        {

            public PardakhtNovinWSContext WSContext { get; set; }
            public string Token { get; set; }
            public string RefNum { get; set; }


        }

        public class PardakhtNovinVerifyTransactionReult
        {
            public string Result { get; set; }
        }
        public enum PardakhtNovinEnTransType
        {

            /// <remarks/>
            enGoods,

            /// <remarks/>
            enBillPay,

            /// <remarks/>
            enVocher,

            /// <remarks/>
            enTopUp,

            /// <remarks/>
            enThpPay,

            /// <remarks/>
            enBillInquery,

            /// <remarks/>
            enThpInquery,

            /// <remarks/>
            enBalance,
        }

    }
}
