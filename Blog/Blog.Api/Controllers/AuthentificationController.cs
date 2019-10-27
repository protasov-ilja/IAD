using Blog.Api.Dtos;
using Blog.Application.AppServices.Authentification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthentificationController : Controller
	{
		[AllowAnonymous]
		[HttpPost]
		public ActionResult<string> Post([FromBody] AuthentificationRequest request, [FromServices] IJwtSigningEncodingKey signingEncodingKey)
		{
			Console.WriteLine($"{request.Login}");
			// 1. Проверяем данные пользователя из запроса.
			// ...
			if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
			{
				return "Error in login or passwotd";
			}

			// 2. Создаем утверждение для токена
			var claims = new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, request.Login)
			};

			// Generate JWT
			var token = new JwtSecurityToken(
				issuer: "Blog.Api",
				audience: "BlogFrontend",
				claims: claims,
				expires: DateTime.Now.AddMinutes(5),
				signingCredentials: new SigningCredentials(
					signingEncodingKey.GetEncodingKey(),
					signingEncodingKey.SigningAlgorithm)
			);

			string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

			return jwtToken;
		}

	}
}
