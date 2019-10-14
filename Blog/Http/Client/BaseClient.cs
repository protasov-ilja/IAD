using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Http.Client
{
	public class BaseClient : IClient
	{
		//	private const int InternalServerError = 500;
		//	private readonly HttpClient _client;

		//	private BaseClient()
		//	{
		//	}

		//	protected BaseClient(HttpClient client, string baseUrl)
		//	{
		//		_client = client;
		//		_client.BaseAddress = new Uri(baseUrl);
		//		_client.DefaultRequestHeaders.Accept.Clear();
		//		_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applciation/json"));
		//	}

		//	public async Task<Response<R>> GetAsync<R>(string url)
		//	{
		//		var result = new Response<R>();

		//		HttpResponseMessage httpResponse = null;
		//		try
		//		{
		//			httpResponse = await _client.GetAsync(url);
		//			if (httpResponse.IsSuccessStatusCode)
		//			{
		//				result.Result = await httpResponse.Content.ReadAsAsync<R>();
		//			}

		//			result.StatusCode = (int)httpResponse.StatusCode;
		//			result.IsSuccessStatusCode = httpResponse.IsSuccessStatusCode;
		//		}
		//		catch (HttpRequestException ex)
		//		{
		//			result.StatusCode = InternalServerError;
		//		}
		//		finally
		//		{
		//			if (httpResponse != null)
		//			{
		//				httpResponse.Dispose();
		//			}
		//		}

		//		return result;
		//	}

		//	public async Task<Response<R>> PostAsync<R, D>(D data, string path)
		//	{
		//		var result = new Response<R>();

		//		HttpResponseMessage httpResponse = null;
		//		try
		//		{
		//			httpResponse = await _client.PostAsJsonAsync(path, data);
		//			if (httpResponse.IsSuccessStatusCode)
		//			{
		//				result.Result = await httpResponse.Content.ReadAsAsync<R>();
		//			}

		//			result.StatusCode = (int)httpResponse.StatusCode;
		//		}
		//		catch(HttpRequestException ex)
		//		{
		//			Console.Write(111);
		//			result.StatusCode = InternalServerError;
		//		}
		//		finally
		//		{
		//			if (httpResponse != null)
		//			{
		//				httpResponse.Dispose();
		//			}
		//		}

		//		return result;
		//	}

		//	public async Task<Response<object>> PostAsync<D>(D data, string path)
		//	{
		//		return await PostAsync<object, D>(data, path);
		//	}
		public Task<Response<R>> GetAsync<R>(string url)
		{
			throw new NotImplementedException();
		}

		public Task<Response<R>> PostAsync<R, D>(D data, string path)
		{
			throw new NotImplementedException();
		}
	}
}
