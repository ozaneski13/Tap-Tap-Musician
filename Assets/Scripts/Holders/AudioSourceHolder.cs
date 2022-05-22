using System.Collections.Generic;
using UnityEngine;

public class AudioSourceHolder : MonoBehaviour
{
    [Header("Musics")]
    [SerializeField] private List<AudioClip> _audioClips = null;

    private int _index = -1;

    public AudioClip GetAudioClip()
    {
        if (_index == _audioClips.Count - 1)
            _index = 0;
        else
            _index++;

        return _audioClips[_index];
    }
}