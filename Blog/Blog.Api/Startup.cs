using Blog.Api.Dtos;
using Blog.Application.AppServices.Authentification;
using Blog.Application.AppServices.Authentification.Key;
using Blog.Infrastructure.Foundation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Blog.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			const string signingScurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
			var signingKey = new SigningSymmetricKey(signingScurityKey);
			services.AddSingleton<IJwtSigningEncodingKey>(signingKey);

			const string jwtSchemeName = "JwtBearer";
			var signingDecodingKey = (IJWtSigningDecodingKey)signingKey;
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = jwtSchemeName;
				options.DefaultChallengeScheme = jwtSchemeName;
			})
				.AddJwtBearer(jwtSchemeName, JwtBearerOptions =>
				{
					JwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = signingDecodingKey.GetDecodingKey(),

						ValidateIssuer = true,
						ValidIssuer = AuthOptions.Issuer,

						ValidateAudience = true,
						ValidAudience = AuthOptions.Audience,

						ValidateLifetime = true,

						ClockSkew = TimeSpan.FromSeconds(AuthOptions.LifeTime)
					};
				});


			//const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
			//var signingKey = new SigningSymmetricKey(signingSecurityKey);
			//services.AddSingleton<IJwtSigningEncodingKey>(signingKey);

			//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			//	.AddJwtBearer(options =>
			//	{
			//		options.RequireHttpsMetadata = true;
			//		options.TokenValidationParameters = new TokenValidationParameters
			//		{
			//			ValidateIssuer = true,
			//			ValidIssuer = AuthOptions.Issuer,

			//			ValidateAudience = true,
			//			ValidAudience = AuthOptions.Audience,

			//			ValidateLifetime = true,

			//			IssuerSigningKey = AuthOptions.GetSymmetricSceurityKey(),
			//			ValidateIssuerSigningKey = true
			//		};
			//	});

			services.AddDependencies().AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			Console.WriteLine(Configuration["Test"]);
			services
				.AddDbContext<BlogDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("BlogConnection")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
