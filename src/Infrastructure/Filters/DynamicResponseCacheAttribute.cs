using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace POC_MGrap.Infrastructure.Filters; 

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
internal class DynamicResponseCacheAttribute : ResponseCacheAttribute
{
    public const string DYNAMIC_CACHE_PROFILE_KEY = "actionDynamicCacheProfile";
}
