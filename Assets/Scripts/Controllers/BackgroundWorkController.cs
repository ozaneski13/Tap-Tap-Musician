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
            Save();

        else
        {
            Player.Instance.LoadPlayer();

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
        Player.Instance.musicalPoint = _musicPointController.CurrentMusicalPointCount;
        Player.Instance.lastSavedTime = DateTime.Now.ToBinary();
        Player.Instance.SavePlayer();
    }
}