namespace Twitter.Web.ViewModels.User
{
    using System.Collections.Generic;
    using Twitter.Web.InputModels;
    using Twitter.Web.ViewModels.Tweets;

    public class UserHomeViewModel
    {
        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public TweetInputModel NewTweet { get; set; }

        public PaginationViewModel PaginationModel { get; set; }
    }
}
