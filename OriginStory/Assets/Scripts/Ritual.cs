using UnityEngine;
using System.Collections;


    //public class Prayer {
    //    //Left = 0
    //    //Right = 1
    //    //Up = 2
    //    public int[] sequence;

    //    public int step { get; set; }

    //    public bool first { get; set; }
    //    public bool second { get; set; }
    //    public bool third { get; set; }
    //    public bool fourth { get; set; }

    //    public void Init() {
    //        step = 0;

    //        sequence = new int[4];
    //        sequence[0] = 0; //Left
    //        sequence[1] = 2; //Up
    //        sequence[2] = 1; //Right
    //        sequence[3] = 2; //Up

    //    }
    //}

public class Ritual : MonoBehaviour {
    public bool praying;
    Prayer prayer;
    Animator anim;
    Vector3 origScale;

    public GameObject group;
    AudioSource music;
    public AudioClip prayerMusic;

    void Awake() {
        anim = GetComponent<Animator>();
        music = GetComponent<AudioSource>();
        prayer = new Prayer();
        prayer.Init();
    }

    void Update() {
        //Start Praying
        if (!praying && Input.GetButton("Pray")) {
            StartPraying();
        }

        //Stop Praying
        if (Input.GetButtonUp("Pray")) {
            StopPraying();
        }

        if (praying) {
            if (Input.GetButtonDown("Left")) {
                int dir = 0;
                ChangePrayer(dir);
                EventManager.TriggerEvent("PrayLeft");
//                CheckSequence(dir);
            }

            if (Input.GetButtonDown("Right")) {
                int dir = 1;
                ChangePrayer(dir);
                EventManager.TriggerEvent("PrayRight");
//                CheckSequence(dir);
            }

            if (Input.GetButtonDown("Up")) {
                int dir = 2;
                ChangePrayer(dir);
                EventManager.TriggerEvent("PrayUp");
//                CheckSequence(dir);
            }
        }

    }

    void StartPraying() {
        praying = true;
        anim.SetBool("Praying", true);
        AudioManager.Instance.PlayPrayer();
        origScale = transform.localScale;
        Vector3 theScale = origScale;
        if (theScale.x < 0) {
            theScale.x *= -1;
        }
        transform.localScale = theScale;
//        Time.timeScale = 0;
        group.SetActive(false);
        EventManager.TriggerEvent("StartRitual");
    }

    void StopPraying() {
        AudioManager.Instance.StopPrayer();
        EventManager.TriggerEvent("StopRitual");
        group.SetActive(true);
        ResetPrayer();
        transform.localScale = origScale;
//        Time.timeScale = 1;
    }

    void ResetPrayer() {
        praying = false;
        anim.SetBool("Praying", false);
        anim.SetBool("PrayLeft", false);
        anim.SetBool("PrayRight", false);
        anim.SetBool("PrayUp", false);
    }
    
    //animations for prayer
    void ChangePrayer(int direction) {
        switch (direction) {
            case 0: //Left, remove right and up
                anim.SetBool("PrayLeft", true);
                anim.SetBool("PrayRight", false);
                anim.SetBool("PrayUp", false);
                break;
            case 1: //Right, remove left and up
                anim.SetBool("PrayRight", true);
                anim.SetBool("PrayLeft", false);
                anim.SetBool("PrayUp", false);
                break;
            case 2:
                anim.SetBool("PrayUp", true);
                anim.SetBool("PrayLeft", false);
                anim.SetBool("PrayRight", false);
                break;
        }
    }

    //bool CheckSequence(int direction) {
    //    bool ret = false;

    //    if (direction == prayer.sequence[prayer.step]) {
    //        prayer.step += 1;
    //        ret = true;
    //    }
    //    else {
    //        ResetSequence();
    //    }

    //    if (prayer.step == 4) {
    //        //Sequence complete
    //        Health.Instance.FeelBetter();
    //        ResetSequence();
    //        Debug.Log("Sequence Complete");
    //    }
    //    return ret;
    //}

    void ResetSequence() {
        prayer.step = 0;
    }
}