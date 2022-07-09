using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [Header("Tap Manager")]
    [SerializeField] private TapManager _tapManager = null;

    [Header("Audio Source Holder")]
    [SerializeField] private AudioSourceHolder _audioSourceHolder = null;

    [Header("Options")]
    [SerializeField] private int _tapThresholdToPlay = 4;
    [SerializeField] private float _checkDuration = 1f;

    private AudioSource _audioSource = null;
    private AudioClip _audioClip = null;

    private float _passedTime = 0f;

    private void Start()
    {
        InitAudio();

        StartCoroutine(CheckMusicStatus());
    }

    private void Update()
    {
        if (_tapManager.TapsPerSecond >= _tapThresholdToPlay)
            PlayMusic();

        else
            StopMusic();

        _passedTime += Time.deltaTime;
    }

    private void InitAudio()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _audioSourceHolder.GetAudioClip();
    }

    private void PlayMusic()
    {
        if (_audioSource.isPlaying)
            return;

        _audioSource.Play();
    }

    private void StopMusic()
    {
        if (!_audioSource.isPlaying)
            return;

        _audioSource.Pause();
    }

    private IEnumerator CheckMusicStatus()
    {
        _audioClip = _audioSource.clip;

        while(true)
        {
            if (_audioClip.length == _passedTime)
                LoadNewSong();

            yield return new WaitForSeconds(_checkDuration);
        }
    }

    public void Load()
    {
        LoadNewSong();
    }

    private void LoadNewSong()
    {
        Debug.Log("Load pressed");

        _audioSource.Stop();

        _audioSource.clip = _audioSourceHolder.GetAudioClip();

        _passedTime = 0f;

        PlayMusic();
    }
}