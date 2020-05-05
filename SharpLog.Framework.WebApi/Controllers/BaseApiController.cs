using Microsoft.AspNetCore.Mvc;
using SharpLog.Core.Interfaces.HandlerPipeline;

namespace SharpLog.Framework.WebAPI.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private IRequestLoader? _requestLoader;

        protected IRequestLoader RequestLoader => _requestLoader ??
            (_requestLoader = (IRequestLoader)HttpContext.RequestServices.GetService(typeof(IRequestLoader)));
    }
}