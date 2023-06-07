using BlazorProject.Models;
using System.Threading.Tasks;

namespace BlazorProject.Client.Service.Contracts
{
    public interface IStripePaymentService
    {
        public Task<StripeSuccessfullModel> Checkout(StripePaymentDto model);
    }
}
