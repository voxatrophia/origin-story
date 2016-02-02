using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : Singleton<Health> {
    public float health = 50;
    public float maxHealth = 100;

    public AudioClip heal;
    AudioSource sound;

    public Slider healthbar;

    void Awake() {
        sound = GetComponent<AudioSource>();
    }

    public void FeelBetter() {
        health = Mathf.Clamp(health + 25f, 0, 100);
        sound.PlayOneShot(heal);
    }

    public void FeelWorse(float amount) {
        health = Mathf.Clamp(health - amount, 0, 100);
        if (health == 0) {
            Scenes.Instance.Restart();
        }
    }

    void Update() {
        healthbar.value = health;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            FeelWorse(25f);
        }

        if (other.CompareTag("Final")) {
            FeelWorse(50f);
        }
    }
}