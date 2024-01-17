using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] backgroundMusics;

    private int previousSound;
    private int currentTrackIndex = 0;
    void Start()
    {
        previousSound = PlayerPrefs.GetInt("soundEffects");
        currentTrackIndex = Random.Range(0, backgroundMusics.Length);
        PlayNextTrack();
    }

    void Update()
    {
        IsVolumeChanged();
        if (!backgroundMusics[currentTrackIndex].isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        backgroundMusics[currentTrackIndex].Stop();
        currentTrackIndex = (currentTrackIndex + 1) % backgroundMusics.Length;
        backgroundMusics[currentTrackIndex].volume = PlayerPrefs.GetInt("soundEffects") == 1 ? 0.5f : 0f;
        backgroundMusics[currentTrackIndex].Play();
    }

    void IsVolumeChanged()
    {
        if(previousSound < PlayerPrefs.GetInt("soundEffects"))
        {
            previousSound = 1;
            backgroundMusics[currentTrackIndex].volume = 0.5f;
        }
        else if(previousSound > PlayerPrefs.GetInt("soundEffects"))
        {
            previousSound = 0;
            backgroundMusics[currentTrackIndex].volume = 0f;
        }
    }
}
