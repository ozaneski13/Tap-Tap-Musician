using UnityEngine;

public class InstrumentController : MonoBehaviour
{
    private Player _player = null;

    private EInstrument _currentInstrument;
    private float _currentExp;
    private float _currentExpGain;

    private void Start()
    {
        _player = Player.Instance;

        LoadSave();
    }

    private void LoadSave()
    {
        _currentInstrument = _player.currentInstrument;
        _currentExp = _player.instrumentExp;
        _currentExpGain = _player.currentExpGain;
    }

    public void IncreaseExp()
    {
        _currentExp += _currentExpGain;
    }
}