using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private MusicalPointController _musicalPointController = null;

    [Header("Power Up Settings")]
    [SerializeField] private ActiveGainPowerUp _activeGainPowerUp = null;
    [SerializeField] private PassiveGainPowerUp _passiveGainPowerUp = null;

    private void CreatePowerUpList()
    {

    }

    public void NotifyPassivePowerUp()
    {
        if (Player.Instance.passivePowerUpRunning)
            _passiveGainPowerUp.StartPowerUp(Player.Instance.passivePowerUpRoutineRemainTime);
    }
}