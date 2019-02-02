using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JwtSecureWebApi.Requirements
{
	public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
		{
			if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth) == false)
			{
				return Task.CompletedTask;
			}
			context.Succeed(requirement);
			return Task.CompletedTask;
		}
	}
}
