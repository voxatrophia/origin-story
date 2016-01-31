using UnityEngine;
using System.Collections;

public class TriggerCamera : MonoBehaviour {
    public int trigger;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            CameraMove.Instance.pos = trigger;
        }
    }
}