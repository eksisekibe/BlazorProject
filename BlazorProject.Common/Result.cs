using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common
{
    public class Result<T> : IResult
    {
        public bool IsSucCess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public Result(bool isSuccess, string message) : this(isSuccess, message, default(T))
        { 

        }
        public Result(bool isSuccess, string message, T data) : this(isSuccess, message, data, 0)
        {

        }
        public Result(bool isSuccess, string message, T data, int totalCount)
        {
            IsSucCess = isSuccess;
            Message = message;
            Data = data;
            TotalCount = totalCount;
        }
    }
}
