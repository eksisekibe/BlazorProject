using BlazorProject.Business.Contracts;
using BlazorProject.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Threading.Tasks;

namespace BlazorProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseOrderController : Controller
    {
        private readonly ICourseOrderInfoRepoistory _courseOrderInfoRepository;

        public CourseOrderController(ICourseOrderInfoRepoistory courseOrderInfoRepository)
        {
            _courseOrderInfoRepository = courseOrderInfoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentSuccessful([FromBody] CourseOrderInfoDto model)
        {
            var service = new SessionService();
            var sessionDetail = service.Get(model.StripeSessionId);
            if (sessionDetail.PaymentStatus =="paid")
            {
                var result = _courseOrderInfoRepository.PaymentSuccessful(model);
                if (result == null)
                    return BadRequest("İşlem Esnasında Hata Oluştur");
                return Ok(result);
            }
            return BadRequest("Ödeme İşlemi Esnasında Hata Oluştur");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseOrderInfoDto model)
        {
            //TODO:Bılerek burada resut olmadan gerıye data don
            if (ModelState.IsValid)
            {
                var result = await _courseOrderInfoRepository.Create(model);
                return Ok(result.Data);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
