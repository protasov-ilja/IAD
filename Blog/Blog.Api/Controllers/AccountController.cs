﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Api.Dtos;
using Blog.Application.AppServices.Authentification;
using Microsoft.AspNetCore.Authorization;
using Blog.Api.Dtos.Account;
using Blog.Application.AppServices.Blogs;

namespace Blog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;
		private readonly IBlogsService _blogsService;

		public AccountController(IAccountService accountService, IBlogsService blogsService)
		{
			_accountService = accountService;
			_blogsService = blogsService;
		}

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
					HttpStatus = 401,
					ErrorInfo = "error login or password!",
				};
			}

			var tokenData = await _accountService.Authentificate(login, password);

			if (!tokenData.IsSuccessCreated)
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					HttpStatus = 401,
					ErrorInfo = tokenData.ErrorInfo
				};
			}

			return new ResponseDto<AuthentificationResponseDto>
			{
				HttpStatus = 200,
				Result = new AuthentificationResponseDto
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
					HttpStatus = 401,
					ErrorInfo = "refresh token data is empty!",
				};
			}

			var tokenData = await _accountService.UpdateAccessToken(request.RefreshToken);

			if (!tokenData.IsSuccessCreated)
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					HttpStatus = 401,
					ErrorInfo = tokenData.ErrorInfo
				};
			}

			return new ResponseDto<AuthentificationResponseDto>
			{
				HttpStatus = 200,
				Result = new AuthentificationResponseDto {
					RefreshToken = tokenData.RefreshToken,
					AccessToken = tokenData.AccessToken 
				}
			};
		}

		[HttpPost("sign-up")]
		[AllowAnonymous]
		public async Task<ResponseDto<AuthentificationResponseDto>> SignUp([FromBody]RegistrationRequestDto request)
		{
			var login = request.Login;
			var password = request.Password;

			if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					HttpStatus = 401,
					ErrorInfo = "error login or password!",
				};
			}

			var tokenData = await _accountService.RegisterUser(login, password, request.FirstName, request.LastName);
			await _blogsService.CreateBlog(login);

			if (!tokenData.IsSuccessCreated)
			{
				return new ResponseDto<AuthentificationResponseDto>
				{
					HttpStatus = 401,
					ErrorInfo = tokenData.ErrorInfo
				};
			}

			return new ResponseDto<AuthentificationResponseDto>
			{
				HttpStatus = 200,
				Result = new AuthentificationResponseDto
				{
					RefreshToken = tokenData.RefreshToken,
					AccessToken = tokenData.AccessToken
				}
			};
		}
	}
}