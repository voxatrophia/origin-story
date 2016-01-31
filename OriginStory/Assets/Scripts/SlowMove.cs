using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class SlowMove : MonoBehaviour {
    public Transform target;
    Rigidbody2D rb;
    float vertSpeed = .4f;
    float hortSpeed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("floatAlong");

        if (target.position.x > transform.position.x) {
            hortSpeed = Random.Range(0.25f, 2f);
        }
        else {
            hortSpeed = Random.Range(-2f, -0.25f);
        }
    }

    void FixedUpdate() {
        float vspd = Mathf.Lerp(rb.velocity.y, vertSpeed, Time.deltaTime);
        rb.velocity = new Vector2(hortSpeed, vspd);
    }

    IEnumerator floatAlong() {
        for (;;) {
            yield return Yielders.Get(1.5f);
            vertSpeed *= -1f;

        }
    }
}