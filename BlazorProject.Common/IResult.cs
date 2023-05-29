using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common
{
    public interface IResult
    {
        bool IsSucCess { get; set; }
        string Message { get; set; }
    }
}
