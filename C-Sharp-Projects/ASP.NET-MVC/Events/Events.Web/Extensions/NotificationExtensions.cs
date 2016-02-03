namespace Events.Web.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class NotificationExtensions
    {
        private static readonly IDictionary<String, String> NotificationKey = new Dictionary<String, String>
        {
            { "Error", "App.Notifications.Error" },
            { "Warning", "App.Notifications.Warning" },
            { "Success", "App.Notifications.Success" },
            { "Info", "App.Notifications.Info" }
        };

        public static void AddNotification(this ControllerBase controller, String message, String notificationType)
        {
            var notificationKey = GetNotificationKeyByType(notificationType);
            var messages = controller.TempData[notificationKey] as ICollection<String>;

            if (messages == null)
            {
                controller.TempData[notificationKey] = (messages = new HashSet<String>());
            }

            messages.Add(message);
        }

        public static IEnumerable<String> GetNotifications(this HtmlHelper htmlHelper, String notificationType)
        {
            var notificationKey = GetNotificationKeyByType(notificationType);
            return htmlHelper.ViewContext.Controller.TempData[notificationKey] as ICollection<String> ?? null;
        }

        private static string GetNotificationKeyByType(string notificationType)
        {
            try
            {
                return NotificationKey[notificationType];
            }
            catch (IndexOutOfRangeException e)
            {
                var exception = new ArgumentException("Key is invalid", "notificationType", e);
                throw exception;
            }
        }
    }

    public static class NotificationType
    {
        public const string Error = "Error";
        public const string Warning = "Warning";
        public const string Success = "Success";
        public const string Info = "Info";
    }
}