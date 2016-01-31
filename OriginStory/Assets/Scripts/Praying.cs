using UnityEngine;
using System.Collections;

public class Prayer {
    //Left = 0
    //Right = 1
    //Up = 2
    public int[] sequence;

    public int step { get; set; }

    public bool first { get; set; }
    public bool second { get; set; }
    public bool third { get; set; }
    public bool fourth { get; set; }

    public void Init() {
        step = 0;

        sequence = new int[4];
        sequence[0] = 0; //Left
        sequence[1] = 2; //Up
        sequence[2] = 1; //Right
        sequence[3] = 2; //Up

    }
}

public class Praying : MonoBehaviour {
    public bool praying;
    Prayer prayer;
    Animator anim;
    Vector3 origScale;

    bool prayFirst;

    void Awake() {
        anim = GetComponent<Animator>();
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
                ChangePrayer(0);
            }
            if (Input.GetButtonDown("Right")) {
                ChangePrayer(1);
            }
            if (Input.GetButtonDown("Up")) {
                ChangePrayer(2);
            }

            //if (Input.GetKeyDown(KeyCode.Alpha1)) {
            //    Debug.Log("Pressed 1");
            //    prayFirst = true;
            //    anim.SetBool("PrayLeft", true);
            //}
            //if (prayFirst && Input.GetKeyDown(KeyCode.Alpha2)) {
            //    Debug.Log("Part 2");
            //}
        }

    }

    void StartPraying() {
        praying = true;
        anim.SetBool("Praying", true);
        origScale = transform.localScale;
        Vector3 theScale = origScale;
        if (theScale.x < 0) {
            theScale.x *= -1;
        }
        transform.localScale = theScale;
        Time.timeScale = 0;

    }

    void StopPraying() {
        ResetPrayer();
        transform.localScale = origScale;
        Time.timeScale = 1;
    }

    void ResetPrayer() {
        praying = false;
        prayer.first = false;
        prayer.second = false;
        prayer.third = false;
        prayer.fourth = false;
        anim.SetBool("Praying", false);
        anim.SetBool("PrayLeft", false);
        anim.SetBool("PrayRight", false);
        anim.SetBool("PrayUp", false);
    }

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
}
