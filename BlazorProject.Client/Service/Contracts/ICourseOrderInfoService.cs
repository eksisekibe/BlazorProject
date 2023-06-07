using BlazorProject.Common;
using BlazorProject.Models;
using System.Threading.Tasks;

namespace BlazorProject.Client.Service.Contracts
{
    public interface ICourseOrderInfoService
    {
        public Task<Result<CourseOrderInfoDto>> SaveCourseOrderInfo(CourseOrderInfoDto model);
        public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto model);
    }
}
