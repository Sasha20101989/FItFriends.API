using FitFriends.Application.Interfaces;
using FitFriends.Logic.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitFriends.Infrastructure.Authentication
{
    public class CustomAuthorizeFilter(IPermissionService permissionService, Permission permission) : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            Claim? userId = context.HttpContext.User.Claims.FirstOrDefault(
                c => c.Type == CustomClaims.UserId);

            if (userId is null || !Guid.TryParse(userId.Value, out Guid id))
            {
                return;
            }

            var permissions = await permissionService.GetPermissionsAsync(id);

            if (!permissions.Contains(permission))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
