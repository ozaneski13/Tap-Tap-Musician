using UnityEngine;
using System;

public class BackgroundWorkController : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private NotificationManager _notificationManager = null;

    [Header("Controllers")]
    [SerializeField] private MusicalPointController _musicPointController = null;
    [SerializeField] private PowerUpController _powerUpController = null;

    private Player _player = null;

    private void Start()
    {
        _player = Player.Instance;

        CheckDifference();
    }

    private void CheckDifference()
    {
        DateTime currentDate = DateTime.Now;

        long tempDate = Player.Instance.lastSavedTime;

        DateTime oldDate = DateTime.FromBinary(tempDate);

        TimeSpan difference = currentDate.Subtract(oldDate);

        _powerUpController.NotifyPassivePowerUp();

        _musicPointController.BackgroundGains(difference.TotalSeconds);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }

        else
        {
            _notificationManager.CancelNotifications();

            _player.LoadPlayer();

            CheckDifference();
        }
    }

    public void Quit()
    {
        Save();

        Application.Quit();
    }

    private void Save()
    {
        _player.musicalPoint = _musicPointController.CurrentMusicalPointCount;
        _player.lastSavedTime = DateTime.Now.ToBinary();
        _player.SavePlayer();

        _notificationManager.ScheduleNotificationBeforeExit();
    }
}