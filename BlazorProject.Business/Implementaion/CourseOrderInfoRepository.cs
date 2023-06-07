using AutoMapper;
using BlazorProject.Business.Contracts;
using BlazorProject.Common;
using BlazorProject.DataAccess.Data;
using BlazorProject.Models;
using BlazorProject.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Business.Implementaion
{
    public class CourseOrderInfoRepository : ICourseOrderInfoRepoistory
    {
        private readonly BlazorContext _ctx;
        private readonly IMapper _mapper;

        public CourseOrderInfoRepository(BlazorContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Result<CourseOrderInfoDto>> Create(CourseOrderInfoDto details)
        {
            try
            {
                var courseOrder = _mapper.Map<CourseOrderInfoDto, CourseOrderInfo>(details);
                courseOrder.Status = ResultConstant.Status_Pending;
                var result = await _ctx.CourseOrderInfos.AddAsync(courseOrder);
                await _ctx.SaveChangesAsync();
                var returnData = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(result.Entity);
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
            }
            catch (Exception ex)
            {
                return new Result<CourseOrderInfoDto>(false, ex.Message.ToString());
            }
        }

        public async Task<Result<CourseOrderInfoDto>> GetCourseOrderInfo(int courseId)
        {
            try
            {
                var data = await _ctx.CourseOrderInfos.Include(c => c.Course).FirstOrDefaultAsync(c => c.Id == courseId);
                var info = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(data);
                info.TotalCount = _ctx.Courses.Where(x => x.Id == courseId).ToList().Count;
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordFound, info);
            }
            catch (Exception ex)
            {
                return new Result<CourseOrderInfoDto>(false, ex.Message.ToString());
            }
        }

        public async Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto details)
        {
            var data = await _ctx.CourseOrderInfos.FindAsync(details.Id);

            if (data == null)
                return null;
            if (!data.IsPaymentSuccessfull)
            {
                data.IsPaymentSuccessfull=true;
                data.Status = ResultConstant.PaymentSuccessfull;
                var result = _ctx.CourseOrderInfos.Update(data);
                await _ctx.SaveChangesAsync();
                var returnData = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(result.Entity);
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
            }
            return new Result<CourseOrderInfoDto>(false, ResultConstant.RecordCreateNotSuccessfully);
        }

        public Task<Result<bool>> UpdateCourseOrderStatus(int courseOrderId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
