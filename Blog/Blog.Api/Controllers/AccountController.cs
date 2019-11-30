using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Api.Dtos;
using Blog.Application.AppServices.Authentification;
using Microsoft.AspNetCore.Authorization;
using Blog.Api.Dtos.Account;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
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
		public async Task<ResponseDto<AuthentificationResponseDto>> Authorize([FromBody]AuthentificationRequestDto request)
		{
			var login = request.Login;
			var password = request.Password;

			if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					Result = 401,
					ErrorInfo = "error login or password!",
				};
			}

			var tokenData = await _accountService.Authentificate(login, password);

			if (!tokenData.IsSuccessCreated)
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					Result = 401,
					ErrorInfo = tokenData.ErrorInfo
				};
			}

			return new ResponseDto<AuthentificationResponseDto>
			{
				Result = 200,
				Data = new AuthentificationResponseDto
				{
					RefreshToken = tokenData.RefreshToken,
					AccessToken = tokenData.AccessToken
				}
			};
		}

		[HttpPost("update-tokens")]
		[AllowAnonymous]
		public async Task<ResponseDto<AuthentificationResponseDto>> UpdateTokens([FromBody] UpdateTokensRequestDto request)
		{
			if (string.IsNullOrEmpty(request.RefreshToken))
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					Result = 401,
					ErrorInfo = "refresh token data is empty!",
				};
			}

			var tokenData = await _accountService.UpdateAccessToken(request.RefreshToken);

			if (!tokenData.IsSuccessCreated)
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					Result = 401,
					ErrorInfo = tokenData.ErrorInfo
				};
			}

			return new ResponseDto<AuthentificationResponseDto>
			{
				Result = 200,
				Data = new AuthentificationResponseDto {
					RefreshToken = tokenData.RefreshToken,
					AccessToken = tokenData.AccessToken 
				}
			};
		}

		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<ResponseDto<AuthentificationResponseDto>> Register([FromBody]RegistrationRequestDto request)
		{
			var login = request.Login;
			var password = request.Password;

			if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					Result = 401,
					ErrorInfo = "error login or password!",
				};
			}

			var tokenData = await _accountService.RegisterUser(login, password, request.FirstName, request.LastName);

			if (!tokenData.IsSuccessCreated)
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					Result = 401,
					ErrorInfo = tokenData.ErrorInfo
				};
			}

			return new ResponseDto<AuthentificationResponseDto>
			{
				Result = 200,
				Data = new AuthentificationResponseDto
				{
					RefreshToken = tokenData.RefreshToken,
					AccessToken = tokenData.AccessToken
				}
			};
		}
	}
}