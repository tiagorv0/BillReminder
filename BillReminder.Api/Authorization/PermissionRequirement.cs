﻿using Microsoft.AspNetCore.Authorization;

namespace BillReminder.Api.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string Role { get; }

    public PermissionRequirement(string role)
    {
        Role = role;
    }
}
