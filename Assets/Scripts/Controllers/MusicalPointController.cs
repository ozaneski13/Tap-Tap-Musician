using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MusicalPointController : MonoBehaviour
{
    [SerializeField] private Text _currentPointText = null;
    [SerializeField] private Text debugtext = null;

    private Player _player = null;

    private double _currentMusicalPointCount;
    public double CurrentMusicalPointCount => _currentMusicalPointCount;

    private float _afkGainPerSecond;
    private float _activeGainPerTap;
    private float _passiveGainPerSecond;

    public Action PowerUpStarted;

    private void Start()
    {
        _player = Player.Instance;

        LoadSave();
    }

    private void LoadSave()
    {
        _currentMusicalPointCount = _player.musicalPoint;

        _afkGainPerSecond = _player.afkGainPerSecond;
        _activeGainPerTap = _player.activeGainPerTap;
        _passiveGainPerSecond = _player.passiveGainPerSecond;
    }

    public void BackgroundGains(double totalSeconds)
    {
        debugtext.text = totalSeconds.ToString();
        _currentMusicalPointCount += totalSeconds * _afkGainPerSecond;
        _currentPointText.text = _currentMusicalPointCount.ToString("F2") + "m";
    }

    public void ActiveGainsFromTap()
    {
        _currentMusicalPointCount += _activeGainPerTap;
        _currentPointText.text = _currentMusicalPointCount.ToString("F2") + "m";
    }

    public void PassiveGains()
    {
        _currentMusicalPointCount += _passiveGainPerSecond;
        _currentPointText.text = _currentMusicalPointCount.ToString("F2") + "m";
    }

    public void StartPowerUpRoutine(float duration, float tempActiveGainMultiplier)
    {
        StartCoroutine(PowerUpRoutine(duration, tempActiveGainMultiplier));
    }

    private IEnumerator PowerUpRoutine(float duration, float tempActiveGainMultiplier)
    {
        float oldActiveGain = _activeGainPerTap;
        _activeGainPerTap = _activeGainPerTap * tempActiveGainMultiplier;

        PowerUpStarted?.Invoke();

        yield return new WaitForSeconds(duration);

        _activeGainPerTap = oldActiveGain;
    }
}