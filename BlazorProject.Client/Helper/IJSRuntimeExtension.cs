using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazorProject.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("DisplayToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("DisplayToastr", "error", message);
        }
    }
}
