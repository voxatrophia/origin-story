using UnityEngine;
using System.Collections;

public class DeathCatcher : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Test");
            Scenes.Instance.Restart();
        }
    }
}