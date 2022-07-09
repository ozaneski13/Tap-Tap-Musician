using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        LoadPlayer();
    }
    #endregion

    [HideInInspector]
    public long lastSavedTime;

    [HideInInspector]
    public double musicalPoint;

    [HideInInspector]
    public float afkGainPerSecond, activeGainPerTap, passiveGainPerSecond;

    public void SavePlayer()
    {
        SaveManager.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveManager.LoadPlayer();

        if(data == null)
        {
            musicalPoint = 0;
            lastSavedTime = System.DateTime.Now.ToBinary();
            musicalPoint = 0;
            afkGainPerSecond = 1;
            activeGainPerTap = 5;
            passiveGainPerSecond = 0;

            return;
        }

        lastSavedTime = data.lastSavedTime;
        musicalPoint = data.currentMusicalPoint;
        afkGainPerSecond = data.afkGainPerSecond;
        activeGainPerTap = data.activeGainPerTap;
        passiveGainPerSecond = data.passiveGainPerSecond;
    }
}