using UnityEngine;

public class DummySaveFile : MonoBehaviour
{
    private long _lastSavedTime = System.DateTime.Now.ToBinary();
    [SerializeField] private float _musicalPoint = 1000f;
    [SerializeField] private float _afkGainPerSecond = 20f;
    [SerializeField] private float _activeGainPerTap = 100f;
    [SerializeField] private float _passiveGainPerSecond = 5f;

    private void Start()
    {
        Player player = new Player();

        player.lastSavedTime = _lastSavedTime;
        player.musicalPoint = _musicalPoint;
        player.afkGainPerSecond = _afkGainPerSecond;
        player.activeGainPerTap = _activeGainPerTap;
        player.passiveGainPerSecond = _passiveGainPerSecond;

        SaveManager.SavePlayer(player);
    }
}