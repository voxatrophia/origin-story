using UnityEngine;
using System.Collections;

public class Health : Singleton<Health> {
    public float health = 50;
    public float maxHealth = 100;

    public void FeelBetter() {
        health = Mathf.Clamp(health + 25f, 0, 100);
    }
}