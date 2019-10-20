using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using Blog.Api.Dtos;

namespace Blog.Api.Controllers
{
	public class UserAuth
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}

	
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private List<UserAuth> people = new List<UserAuth>
		{
			new UserAuth {Login="admin@gmail.com", Password="12345", Role = "admin" },
			new UserAuth { Login="qwerty", Password="55555", Role = "user" }
		};

		[HttpPost("/token")]
		public async Task Token()
		{
			var username = Request.Form["username"];
			var password = Request.Form["password"];

			var identity = GetIdentity(username, password);
			if (identity == null)
			{
				Response.StatusCode = 400;
				await Response.WriteAsync("Invalid username or password");
				return;
			}

			var now = DateTime.UtcNow;
			// create JWT token
			var jwt = new JwtSecurityToken(
				issuer: AuthOptions.Issuer,
				audience: AuthOptions.Audience,
				notBefore: now,
				claims: identity.Claims,
				expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
				signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSceurityKey(), SecurityAlgorithms.HmacSha256));
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			var response = new
			{
				accessToken = encodedJwt,
				username = identity.Name
			};

			// answer serialization 
			Response.ContentType = "application/json";
			await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			}));
		}

		private ClaimsIdentity GetIdentity(string username, string password)
		{
			UserAuth person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
			if (person != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
					new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role),
				};

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultRoleClaimType);

				return claimsIdentity;
			}

		// if user not found
			return null;
		}

		[HttpPost]
		public async Task<IActionResult> Authorize([FromBody]LoginDto loginData)
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}

		public async Task<IActionResult> Logout()
		{
			throw new NotImplementedException("Authorization logic not emplemented");
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody]RegistrationDto registrationData)
		{
			throw new NotImplementedException("register logic not implemented");
		}
	}
}
