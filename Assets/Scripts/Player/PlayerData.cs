[System.Serializable]
public class PlayerData
{
    public double currentMusicalPoint;
    public long lastSavedTime;

    public float afkGainPerSecond;
    public float activeGainPerTap;
    public float passiveGainPerSecond;

    public EInstruments currentInstrument;
    public float instrumentExp;
    public float currentExpGain;

    public PlayerData(Player player)
    {
        currentMusicalPoint = player.musicalPoint;
        lastSavedTime = player.lastSavedTime;
        afkGainPerSecond = player.afkGainPerSecond;
        activeGainPerTap = player.activeGainPerTap;
        passiveGainPerSecond = player.passiveGainPerSecond;
        currentInstrument = player.currentInstrument;
        instrumentExp = player.instrumentExp;
        currentExpGain = player.currentExpGain;
    }
}