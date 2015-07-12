namespace Twitter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Twitter.Data;
    using Twitter.Models;
    using Twitter.Web.Helpers;
    using Twitter.Web.Hubs;
    using Twitter.Web.InputModels;
    using Twitter.Web.ViewModels.Alerts;
    using Twitter.Web.ViewModels.Tweets;

    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult GetById(int id)
        {
            var tweet = this.Data.Tweets
                .All()
                .Project()
                .To<TweetViewModel>()
                .FirstOrDefault(t => t.Id == id);

            return this.PartialView("~/Views/Shared/DisplayTemplates/TweetViewModel.cshtml", tweet);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddTweet(TweetInputModel newTweet)
        {
            if (this.ModelState.IsValid)
            {
                var tweet = new Tweet
                {
                    Text = newTweet.Text,
                    TweetedAt = DateTime.Now,
                    OwnerId = this.CurrentUserId,
                    RetweetCount = 0,
                    SharedCount = 0
                };

                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();
                this.AddAlert("Tweet posted successfully", AlertType.Success);
                TweetsHub.OnTweetAdded(tweet.Id, this.GetFollowerIds());
            }
            else
            {
                foreach (var error in this.ModelState.Values.SelectMany(m => m.Errors))
                {
                    this.AddAlert(error.ErrorMessage, AlertType.Error);
                }
            }

            return this.RedirectToAction("Index", "User", new { username = this.User.GetUsername() });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Retweet(int id)
        {
            var tweet = this.Data.Tweets.Find(id);
            if (tweet == null)
            {
                return this.HttpNotFound();
            }

            var newTweet = new Tweet
            {
                Text = tweet.Text,
                OwnerId = this.CurrentUserId,
                RetweetedFromId = id,
                TweetedAt = DateTime.Now,
                RetweetCount = 0,
                SharedCount = 0
            };

            this.Data.Tweets.Add(newTweet);
            tweet.RetweetCount++;
            this.AddRetweetNotification(tweet, this.User.GetUsername());
            this.Data.SaveChanges();
            TweetsHub.OnTweetAdded(newTweet.Id, this.GetFollowerIds());
            NotificationsHub.OnNotificationAdded(tweet.OwnerId);

            return this.Content("Tweet retweeted successfully.");
        }

        public ActionResult GetUserTweets(string username)
        {
            var tweets = this.Data.Tweets
                .All()
                .Where(t => t.Owner.UserName == username)
                .OrderByDescending(t => t.TweetedAt)
                .Project()
                .To<TweetViewModel>()
                .ToList();

            TweetViewModel.SetFavouriteFlags(tweets, this.CurrentUser);

            return this.PartialView("_TweetList", tweets);
        }

        public ActionResult GetFavouriteTweets(string username)
        {
            var tweets = this.Data.Tweets
                .All()
                .Where(t => t.FavouredBy.Any(u => u.UserName == username))
                .OrderByDescending(t => t.TweetedAt)
                .Project()
                .To<TweetViewModel>()
                .ToList();

            TweetViewModel.SetFavouriteFlags(tweets, this.CurrentUser);

            return this.PartialView("_TweetList", tweets);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddFavouriteTweet(int id)
        {
            var tweet = this.Data.Tweets.Find(id);
            if (tweet == null)
            {
                return this.HttpNotFound();
            }

            this.CurrentUser.FavouriteTweets.Add(tweet);
            this.AddFavouriteNotification(tweet, this.User.GetUsername());
            this.Data.SaveChanges();
            NotificationsHub.OnNotificationAdded(tweet.OwnerId);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFavouriteTweet(int id)
        {
            var tweet = this.Data.Tweets.Find(id);
            if (tweet == null)
            {
                return this.HttpNotFound();
            }

            this.CurrentUser.FavouriteTweets.Remove(tweet);
            this.Data.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [Authorize]
        public ActionResult ShowReportForm(int id)
        {
            var reportModel = new ReportInputModel { TweetId = id };

            return this.PartialView("~/Views/Shared/EditorTemplates/ReportInputModel.cshtml", reportModel);
        }

        private void AddRetweetNotification(Tweet tweet, string username)
        {
            var notification = new Notification
            {
                Text = username + " retweeted your tweet.",
                NotificationTime = DateTime.Now,
                Type = NotificationType.TweetRetweeted,
                IsRead = false,
                UserId = tweet.OwnerId
            };
            
            this.Data.Notifications.Add(notification);
        }

        private void AddFavouriteNotification(Tweet tweet, string username)
        {
            var notification = new Notification
            {
                Text = username + " favoured your tweet.",
                NotificationTime = DateTime.Now,
                Type = NotificationType.TweetFavoured,
                IsRead = false,
                UserId = tweet.OwnerId
            };

            this.Data.Notifications.Add(notification);
        }

        private IList<string> GetFollowerIds()
        {
            var followerIds = this.Data.Users
                .All()
                .Where(u => u.Id == this.CurrentUserId)
                .SelectMany(u => u.Followers.Select(f => f.Id))
                .ToList();

            return followerIds;
        }
    }
}
