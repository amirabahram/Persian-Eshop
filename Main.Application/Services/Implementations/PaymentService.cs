using Dto.Payment;
using Dto.Response.Payment;
using Main.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarinPal.Class;

namespace Main.Application.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private Payment _payment;
        private Authority _authority;
        private Transactions _transactions;
        public PaymentService()
        {
            var expose = new Expose();
             _payment = expose.CreatePayment();
             _authority = expose.CreateAuthority();
             _transactions = expose.CreateTransactions();
        }

        public async Task<Request> RequestZarin(int amount,int cartId)
        {
            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = "09121112222",
                CallbackUrl = "http://Amir-Alaei-Eshop.somee.com/Cart/OnlinePayment/" + cartId,
                Description = $"پرداخت فاکتور شماره{cartId}",
                Email = "farazmaan@outlook.com",
                Amount = amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, ZarinPal.Class.Payment.Mode.sandbox);
            return result;
        }

        public async Task<Verification> VerificationZarin(string authority,int totalPrice)
        {
           return await _payment.Verification(new DtoVerification
            {
                Amount = totalPrice,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);
        }
    }
}
