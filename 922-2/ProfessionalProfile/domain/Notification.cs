namespace ProfessionalProfile.Domain
{
    public class Notification
    {
        private int notificationId;
        private int userId;
        private string activity;
        private DateTime timestamp;
        private string details;
        private bool isRead;

        public Notification(int notificationId, int userId, string activity, DateTime timestamp, string details, bool isRead)
        {
            this.notificationId = notificationId;
            this.userId = userId;
            this.activity = activity;
            this.timestamp = timestamp;
            this.details = details;
            this.isRead = isRead;
        }

        public int NotificationId
        {
            get { return notificationId; }
            set { notificationId = value; }
        }

        public int UserId
        {
            get { return userId; } set { userId = value; }
        }

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public bool IsRead
        {
            get { return this.isRead; }
            set { this.isRead = value; }
        }

        public override bool Equals(object? obj)
        {
            return obj is Notification notification &&
                   notificationId == notification.notificationId &&
                   userId == notification.userId &&
                   activity == notification.activity &&
                   timestamp == notification.timestamp &&
                   details == notification.details &&
                   isRead == notification.isRead &&
                   NotificationId == notification.NotificationId &&
                   UserId == notification.UserId &&
                   Activity == notification.Activity &&
                   Timestamp == notification.Timestamp &&
                   Details == notification.Details &&
                   IsRead == notification.IsRead;
        }
    }
}
