using FitFriends.Logic.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FitFriends.Infrastructure.Authentication
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(Permission permission) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = [permission];
        }
    }
}
