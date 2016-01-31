using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager> {
    public AudioClip prayerMusic;
    AudioSource music;

    void Awake() {
        music = GetComponent<AudioSource>();
    }

    public void PlayPrayer() {
        music.clip = prayerMusic;
        music.Play();
    }

    public void StopPrayer() {
        music.Stop();
    }	
}