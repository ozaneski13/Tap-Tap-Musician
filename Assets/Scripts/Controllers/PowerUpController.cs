using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private MusicalPointController _musicalPointController = null;

    [Header("Power Up Settings")]
    [SerializeField] private List<PowerUp> _powerUps = null;

    private List<PowerUp> _currentPowerUpList = null;

    private bool _activePowerUpRunning = false;
    private bool _passivePowerUpRunning = false;

    private void CreatePowerUpList()
    {

    }
}