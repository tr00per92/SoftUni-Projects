namespace Twitter.Web.ViewModels.Notifications
{
    using System;
    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class NotificationViewModel : IMapFrom<Notification>
    {
        public NotificationType Type { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public DateTime NotificationTime { get; set; }
    }
}
