using Unity.Notifications.Android;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public void ScheduleNotificationBeforeExit()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notification Channel",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        notification.Title = "Hey! Come back!";
        notification.Text = "You should practice more on your instrument!";
        notification.FireTime = System.DateTime.Now.AddHours(6);
        notification.ShowTimestamp = true;

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }

    public void CancelNotifications()
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }
}