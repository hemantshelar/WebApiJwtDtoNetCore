﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtSecureWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }

		[HttpPost("Token")]
		public IActionResult Token()
		{
			//Security key
			var securityKey = Constants.SecurityKey;

			//symetric key
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

			//signing credentials
			var signingCredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

			//add claims
			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Role,"Administrator"));
			claims.Add(new Claim(ClaimTypes.DateOfBirth, "1981-6-5"));
			
			//create token
			var token = new JwtSecurityToken(
				issuer: Constants.Issure
				,audience: Constants.Audience
				,signingCredentials: signingCredintials
				,claims: claims
				,expires: DateTime.Now.AddMinutes(5));



			return Ok(new JwtSecurityTokenHandler().WriteToken(token));

		}
    }
}