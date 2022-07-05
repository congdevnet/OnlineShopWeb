using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.FeedbackServices
{
    public class FeedbackService: GenericService<Feedback>, IFeedbackServices
    {
        public FeedbackService(IRepository repository) : base(repository) { }
    }
}