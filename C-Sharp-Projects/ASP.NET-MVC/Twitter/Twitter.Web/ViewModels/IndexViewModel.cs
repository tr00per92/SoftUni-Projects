namespace Twitter.Web.ViewModels
{
    using System.Collections.Generic;
    using Twitter.Web.ViewModels.Tweets;

    public class IndexViewModel
    {
        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public PaginationViewModel PaginationModel { get; set; }
    }
}