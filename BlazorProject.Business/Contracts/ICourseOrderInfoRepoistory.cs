using BlazorProject.Common;
using BlazorProject.Models;
using System.Threading.Tasks;

namespace BlazorProject.Business.Contracts
{
    public interface ICourseOrderInfoRepoistory
    {
        public Task<Result<CourseOrderInfoDto>> Create(CourseOrderInfoDto details);
        public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto details);
        public Task<Result<CourseOrderInfoDto>> GetCourseOrderInfo(int courseId);
        public Task<Result<bool>> UpdateCourseOrderStatus(int courseOrderId,string status);
    }
}
