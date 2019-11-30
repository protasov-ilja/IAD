namespace Blog.Application.AppServices.Authentification
{
	public struct TokensData
	{
		public bool IsSuccessCreated { get; set; }
		public string ErrorInfo { get; set; }
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	}
}
