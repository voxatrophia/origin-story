﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalRitual : Singleton<FinalRitual> {
    public bool praying;
    public GameObject final;
    public int totalRounds;
    public float speed;

    public AudioClip drum;
    public AudioClip bell;
    AudioSource sound;

    public Image black;

    //what step in the sequence
    int step;

    //how many sequences finished so far
    int round;


    void OnEnable() {
        EventManager.StartListening("StartRitual", StartRitual);
        EventManager.StartListening("StopRitual", ResetRitual);
        EventManager.StartListening("PrayLeft", CheckLeft);
        EventManager.StartListening("PrayRight", CheckRight);
        EventManager.StartListening("PrayUp", CheckUp);
    }

    void OnDisable() {
        EventManager.StopListening("StartRitual", StartRitual);
        EventManager.StopListening("StopRitual", ResetRitual);
        EventManager.StopListening("PrayLeft", CheckLeft);
        EventManager.StopListening("PrayRight", CheckRight);
        EventManager.StopListening("PrayUp", CheckUp);
    }

    void Awake() {
        sound = GetComponent<AudioSource>();
        black.gameObject.SetActive(false);
        step = 0;
        round = 1;

        final.SetActive(false);
       
    }

    void CheckLeft() {
        if(step == 0) {
            sound.PlayOneShot(drum);
            step++;
            final.SetActive(false);
            final.SetActive(true);
        }
    }

    void CheckRight() {
        if (step == 2) {
            sound.PlayOneShot(drum);
            step++;
            final.SetActive(false);
            final.SetActive(true);
        }
    }

    void CheckUp() {
        if (step == 1) {
            sound.PlayOneShot(drum);
            step++;
            final.SetActive(false);
            final.SetActive(true);
        }

        if (step == 3) {
            step = 0;
            if (round < totalRounds) {
                sound.PlayOneShot(drum);
                round++;
                final.SetActive(false);
                final.SetActive(true);
            }
            else {
                sound.PlayOneShot(bell);
                final.SetActive(false);
                EventManager.TriggerEvent("Victory");
                CheckPoint.Instance.saved = false;
                Invoke("EndGame", 2.5f);
                Fader.Instance.FadeToBlack();
                Invoke("BlackOut", 1.5f);
            }
        }
    }

    void StartRitual() {
        final.SetActive(true);
    }

    void ResetRitual() {
        final.SetActive(false);
        round = 0;
    }

    public int GetRound() {
        return round;
    }

    public int GetStep() {
        return step;
    }

    void BlackOut() {
        black.gameObject.SetActive(true);
    }

    void EndGame() {
        Scenes.Instance.Victory();
    }

}