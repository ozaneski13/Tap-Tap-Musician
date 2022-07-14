using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicHolderController : MonoBehaviour
{
    [Header("Music Holders")]
    [SerializeField] private List<MusicHolder> _musicHolders = null;

    private Player _player = null;

    private MusicHolder _audioClipHolder = null;
    private List<AudioClip> _audioClips = null;

    private int _index = -1;

    public Action AudioHolderInitialized;

    private void Start()
    {
        _player = Player.Instance;

        LoadSave();
    }

    private void LoadSave()
    {
        ChangeCurrentMusicType(_player.currentInstrument);
    }

    public void ChangeCurrentMusicType(EInstrument newInstrument)
    {
        _audioClipHolder = _musicHolders[(int)newInstrument];
        _audioClips = _audioClipHolder.AudioClips;

        _index = -1;

        AudioHolderInitialized?.Invoke();
    }

    public AudioClip GetAudioClip()
    {
        if (_index == _audioClips.Count - 1)
            _index = 0;

        else
            _index++;

        return _audioClips[_index];
    }
}