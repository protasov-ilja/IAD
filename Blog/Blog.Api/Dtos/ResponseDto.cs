namespace Blog.Api.Dtos
{
	public class ResponseDto<T>
	{
		public int Result { get; set; }
		public string ErrorInfo { get; set; }
		public T Data { get; set; }
	}
}
