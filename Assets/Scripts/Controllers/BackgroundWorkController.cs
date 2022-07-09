using UnityEngine;
using System;

public class BackgroundWorkController : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private NotificationManager _notificationManager = null;

    [Header("Controllers")]
    [SerializeField] private MusicalPointController _musicPointController = null;

    private void Start()
    {
        CheckDifference();
    }

    private void CheckDifference()
    {
        DateTime currentDate = DateTime.Now;

        long tempDate = Player.Instance.lastSavedTime;

        DateTime oldDate = DateTime.FromBinary(tempDate);

        TimeSpan difference = currentDate.Subtract(oldDate);

        _musicPointController.BackgroundGains(difference.TotalSeconds);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();

            _notificationManager.ScheduleNotificationBeforeExit();
        }

        else
        {
            _notificationManager.CancelNotifications();

            Player.Instance.LoadPlayer();

            CheckDifference();
        }
    }

    public void Quit()
    {
        Save();

        _notificationManager.ScheduleNotificationBeforeExit();

        Application.Quit();
    }

    private void Save()
    {
        Player.Instance.musicalPoint = _musicPointController.CurrentMusicalPointCount;
        Player.Instance.lastSavedTime = DateTime.Now.ToBinary();
        Player.Instance.SavePlayer();
    }
}