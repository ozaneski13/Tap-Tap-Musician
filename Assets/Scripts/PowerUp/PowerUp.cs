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

    public Action PowerUpSelected;
    public Action<EGain, float, float> PowerUpStarted;
    public Action PowerUpEnded;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = _powerUpSprite;
    }

    public void PowerUpTapped()
    {
        PowerUpSelected?.Invoke();
    }

    public void StartPowerUp()
    {
        PowerUpStarted?.Invoke(_gainType, _duration, _gainIncreaseMultiplier);

        StartCoroutine(PowerUpRoutine());
    }

    private IEnumerator PowerUpRoutine()
    {
        yield return new WaitForSeconds(_duration);

        PowerUpEnded?.Invoke();
    }
}