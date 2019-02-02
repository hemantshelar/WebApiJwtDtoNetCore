using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtSecureWebApi.Requirements
{
	public class MinimumAgeRequirement : IAuthorizationRequirement
	{
		public int Age { get;private set; }
		public MinimumAgeRequirement(int nAge)
		{
			Age = nAge;
		}
	}
}
