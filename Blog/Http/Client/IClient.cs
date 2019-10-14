using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Http.Client
{
	public interface IClient
	{
		Task<Response<R>> PostAsync<R, D>(D data, string path);
		Task<Response<R>> GetAsync<R>(string url);
	}
}
