using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Api.Dtos;
using Blog.Application.AppServices.Authentification;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		//[HttpPost("/token")]
		//public async Task Token()
		//{
		//	var username = Request.Form["username"];
		//	var password = Request.Form["password"];

		//	var identity = GetIdentity(username, password);
		//	if (identity == null)
		//	{
		//		Response.StatusCode = 400;
		//		await Response.WriteAsync("Invalid username or password");
		//		return;
		//	}

		//	var now = DateTime.UtcNow;
		//	// create JWT token
		//	var jwt = new JwtSecurityToken(
		//		issuer: AuthOptions.Issuer,
		//		audience: AuthOptions.Audience,
		//		notBefore: now,
		//		claims: identity.Claims,
		//		expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
		//		signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSceurityKey(), SecurityAlgorithms.HmacSha256));
		//	var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

		//	var response = new
		//	{
		//		accessToken = encodedJwt,
		//		username = identity.Name
		//	};

		//	// answer serialization 
		//	Response.ContentType = "application/json";
		//	await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
		//	{
		//		Formatting = Formatting.Indented
		//	}));
		//}

		//private ClaimsIdentity GetIdentity(string username, string password)
		//{
		//	UserAuth person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
		//	if (person != null)
		//	{
		//		var claims = new List<Claim>
		//		{
		//			new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
		//			new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role),
		//		};

		//		ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
		//			ClaimsIdentity.DefaultRoleClaimType);

		//		return claimsIdentity;
		//	}

		//	return null;
		//}

		[HttpPost("authorize")]
		[AllowAnonymous]
		public async Task<IActionResult> Authorize([FromBody]AuthentificationRequest request)
		{
			var login = request.Login;
			var password = request.Password;

			if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
			{
				return Ok("error login or password!");
			}

			var tokenData = await _accountService.Authentificate(login, password);

			return Ok(tokenData);
		}

		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody]RegistrationRequest request)
		{
			var login = request.Login;
			var password = request.Password;

			if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
			{
				return Ok("error login or password!");
			}

			var tokenData = await _accountService.RegisterUser(login, password, request.FirstName, request.LastName);

			return Ok(tokenData);
		}
	}
}