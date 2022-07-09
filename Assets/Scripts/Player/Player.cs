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

    public long lastSavedTime;
    public double musicalPoint;
    public float afkGainPerSecond;
    public float activeGainPerTap;
    public float passiveGainPerSecond;

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

            return;
        }

        lastSavedTime = data.lastSavedTime;
        musicalPoint = data.currentMusicalPoint;
        afkGainPerSecond = data.afkGainPerSecond;
        activeGainPerTap = data.activeGainPerTap;
        passiveGainPerSecond = data.passiveGainPerSecond;
    }
}