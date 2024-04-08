using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private bool _isPlaying;
    private float _curretMasterVolum;

    private void Awake()
    {
        _isPlaying = true;
        _curretMasterVolum = 0;
    }

    public void OnClickButtonOnAndOffAudio()
    {
        if (_isPlaying)
        {
            _isPlaying = false;
            _audioMixer.audioMixer.GetFloat("Master", out _curretMasterVolum);
            _audioMixer.audioMixer.SetFloat("Master", -80);
        }
        else
        {
            _isPlaying = true;
            _audioMixer.audioMixer.SetFloat("Master", _curretMasterVolum);
        }
    }

    public void ChangeVolumeMaster(float volume)
    {
        _curretMasterVolum = Mathf.Lerp(-80, 0, volume);

        if (_isPlaying )
        {
            _audioMixer.audioMixer.SetFloat("Master", _curretMasterVolum);
        }
    }

    public void ChangeVolumeButtons(float volume)
    {
        _audioMixer.audioMixer.SetFloat("Buttons", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeVolumBackground(float volume)
    {
        _audioMixer.audioMixer.SetFloat("Background", Mathf.Lerp(-80, 0, volume));
    }
}
