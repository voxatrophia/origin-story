using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    Rigidbody2D rb;
    public Vector2 vel;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = vel;
    }

}
