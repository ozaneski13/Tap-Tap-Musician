[System.Serializable]
public class PlayerData
{
    public double currentMusicalPoint;
    public long lastSavedTime;

    public float afkGainPerSecond;
    public float activeGainPerTap;

    public float currentPassiveGainPerSecond;
    public float passiveGainPerSecond;
    public bool passivePowerUpRunning;
    public float passivePowerUpRoutineRemainTime;

    public EInstrument currentInstrument;
    public float instrumentExp;
    public float currentExpGain;

    public PlayerData(Player player)
    {
        currentMusicalPoint = player.musicalPoint;
        lastSavedTime = player.lastSavedTime;
        afkGainPerSecond = player.afkGainPerSecond;
        activeGainPerTap = player.activeGainPerTap;
        currentPassiveGainPerSecond = player.currentPassiveGainPerSecond;
        passiveGainPerSecond = player.passiveGainPerSecond;
        passivePowerUpRunning = player.passivePowerUpRunning;
        passivePowerUpRoutineRemainTime = player.passivePowerUpRoutineRemainTime;
        currentInstrument = player.currentInstrument;
        instrumentExp = player.instrumentExp;
        currentExpGain = player.currentExpGain;
    }
}