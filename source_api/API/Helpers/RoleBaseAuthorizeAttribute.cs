/*
 * author: LeHuynhGiang
 * ref:https://docs.microsoft.com/en-us/aspnet/core/security/authorization/iauthorizationpolicyprovider?view=aspnetcore-3.1
 * ref:https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.iauthorizationfilter.onauthorization?view=aspnetcore-3.1#Microsoft_AspNetCore_Mvc_Filters_IAuthorizationFilter_OnAuthorization_Microsoft_AspNetCore_Mvc_Filters_AuthorizationFilterContext_
 */
using Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    public class RoleBaseAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private ERole[] m_roles;
        public RoleBaseAuthorizeAttribute(params ERole[] roles)
        {
            m_roles = roles;
        }

        //Called early in the filter pipeline to confirm request is authorized.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var l_role = (ERole)context.HttpContext.Items["Role"];//get "Role" item in httpcontext
            foreach (ERole role in m_roles)
            {
                //if (System.String.Compare(role, l_role, System.StringComparison.OrdinalIgnoreCase))
                if ((int)role == (int)l_role) return;
            }
            context.Result = new UnauthorizedObjectResult(new { message = "Unauthorized" });
        }
    }
}
