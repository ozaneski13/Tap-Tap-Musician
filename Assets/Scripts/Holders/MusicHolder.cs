using System.Collections.Generic;
using UnityEngine;

public class MusicHolder : MonoBehaviour
{
    [Header("Holder Settings")]
    [SerializeField] private EInstrument _musicInstrumentType = EInstrument.None;
    public EInstrument musicInstrumentType => _musicInstrumentType;

    [SerializeField] private List<AudioClip> _audioClips = null;
    public List<AudioClip> AudioClips => _audioClips;
}