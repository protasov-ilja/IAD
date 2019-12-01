using System.Threading.Tasks;

namespace Blog.Application.AppServices.Subscription
{
	public interface ISubscriptionsService
	{
		Task<SubscriptionResult> SubscribedOnBlog(string login, int blogId);
		Task<SubscriptionResult> UnsubscribedOnBlog(string login, int blogId);
	}
}
