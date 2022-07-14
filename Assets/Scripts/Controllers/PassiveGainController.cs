using System.Collections;
using UnityEngine;

public class PassiveGainController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private MusicalPointController _musicalPointController = null;

    [Header("Settings")]
    [SerializeField] private float _passiveGainDuration = 0.5f;

    private Player _player = null;

    private IEnumerator _passiveGainRoutine = null;

    private float _passiveGainPerSecond;
    private float _currentPassiveGainPerSecond;

    private bool _isPowerUpRunning = false;
    public bool IsPowerUpRunning => _isPowerUpRunning;

    private void Start()
    {
        _player = Player.Instance;

        LoadSave();

        _passiveGainRoutine = PassiveGainRoutine();
        StartCoroutine(_passiveGainRoutine);
    }

    private void LoadSave()
    {
        _passiveGainPerSecond = _player.passiveGainPerSecond;
        _currentPassiveGainPerSecond = _player.currentPassiveGainPerSecond;
    }

    public void PassivePowerUp(float gain, float duration)
    {
        StartCoroutine(PassivePowerUpRoutine(gain, duration));
    }

    public void PassiveGainInreased(float gain)
    {
        _passiveGainPerSecond = gain;

        if (!_isPowerUpRunning)
            _currentPassiveGainPerSecond = _passiveGainPerSecond;
    }

    private IEnumerator PassiveGainRoutine()
    {
        while (true)
        {
            _musicalPointController.PassiveGains(_currentPassiveGainPerSecond);

            yield return new WaitForSeconds(_passiveGainDuration);
        }
    }

    private IEnumerator PassivePowerUpRoutine(float gain, float duration)
    {
        _isPowerUpRunning = true;

        _passiveGainPerSecond = _currentPassiveGainPerSecond;
        _currentPassiveGainPerSecond = gain;

        yield return new WaitForSeconds(duration);

        _isPowerUpRunning = false;
        _currentPassiveGainPerSecond = _passiveGainPerSecond;
    }
}