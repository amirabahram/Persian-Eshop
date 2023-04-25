using Dto.Response.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Request> RequestZarin(int amount,int cartId);
        Task<Verification> VerificationZarin(string authority, int totalPrice);
 
        
    }
}
