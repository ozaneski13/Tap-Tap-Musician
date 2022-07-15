using UnityEngine;
using System;
using System.Collections;

public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    [Header("Stats")]
    [SerializeField] protected EGain _gainType = EGain.None;
    [SerializeField] protected float _duration = 20f;
    [SerializeField] protected float _gainIncreaseMultiplier = 2f;

    [Header("UI")]
    [SerializeField] private Sprite _powerUpSprite = null;
    private SpriteRenderer _spriteRenderer = null;

    private Player _player = null;

    private float _remainPowerUpTime;

    private bool _powerUpRoutineRunning = false;

    public Action PowerUpSelected;
    public Action<EGain, float, float> PowerUpStarted;
    public Action PowerUpEnded;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _player = Player.Instance;

        _spriteRenderer.sprite = _powerUpSprite;
    }

    private void Update()
    {
        if (_remainPowerUpTime > 0)
            _remainPowerUpTime -= Time.deltaTime;
        else
            _remainPowerUpTime = 0;

        if (_powerUpRoutineRunning)
            _player.passivePowerUpRoutineRemainTime = _remainPowerUpTime;
    }

    public void PowerUpTapped()
    {
        PowerUpSelected?.Invoke();
    }

    public void StartPowerUp()
    {
        StartCoroutine(PowerUpRoutine(_duration));
    }

    public void StartPowerUp(float remainTime)
    {
        StartCoroutine(PowerUpRoutine(remainTime));
    }

    private IEnumerator PowerUpRoutine(float duration)
    {
        PowerUpStarted?.Invoke(_gainType, duration, _gainIncreaseMultiplier);
        _player.passivePowerUpRunning = true;
        _powerUpRoutineRunning = true;
        _remainPowerUpTime = _duration;
        
        yield return new WaitForSeconds(duration);

        _player.passivePowerUpRunning = false;
        _powerUpRoutineRunning = false;
        PowerUpEnded?.Invoke();
    }
}