using Main.Domain.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface ICartRepository
    {
       Task Insert(Cart cart);
       Task Update(Cart cart);
       Task Save();

}
