using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BillReminder.Api.Authorization;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var permissions = context.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
        if (permissions.Contains(requirement.Role))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
