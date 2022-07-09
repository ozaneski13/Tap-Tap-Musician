using UnityEngine;
using System;

public class BackgroundWorkController : MonoBehaviour
{
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
        if(pause)
        {
            Player.Instance.musicalPoint = _musicPointController.CurrentMusicalPointCount;
            Player.Instance.SavePlayer();
        }

        else
        {
            Player.Instance.LoadPlayer();

            CheckDifference();
        }
    }

    public void Quit()
    {
        Player.Instance.SavePlayer();

        Application.Quit();
    }
}