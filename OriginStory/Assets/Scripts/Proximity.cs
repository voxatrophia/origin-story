using UnityEngine;
using System.Collections;

public class Proximity : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Final")) {
            SpriteRenderer spr = other.gameObject.GetComponent<SpriteRenderer>();
            spr.color = Color.red;
        }
    }
	
}