﻿using Microsoft.AspNetCore.Authorization;

namespace TDTapi.Auth
{
    public class OnlyEmployeesRequirement : IAuthorizationRequirement
    {
    }
}
