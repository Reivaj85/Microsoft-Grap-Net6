using Microsoft.AspNetCore.Mvc;
using POC_MGrap.Infrastructure.Filters;

namespace POC_MGrap.Controllers; 

public class BaseController : ControllerBase
{
    protected void CacheFor(TimeSpan cacheDuration)
    {
        Request.HttpContext.Items[DynamicResponseCacheAttribute.DYNAMIC_CACHE_PROFILE_KEY] = new CacheProfile
        {
            Duration = (int?)cacheDuration.TotalSeconds
        };
    }

}
