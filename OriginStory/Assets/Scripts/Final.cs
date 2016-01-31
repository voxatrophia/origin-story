using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Final : MonoBehaviour {
    public float speed;

    bool inRange;
    Rigidbody2D rb;
    int step;
    int round;
    float multiplier;

    Vector3[] positions;
    Vector3[] sequence;
    Vector2[] velocities;
    Vector2[] vel_seq;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        positions = new Vector3[3];
        positions[0] = new Vector3(73f, 25f, 0);//Left = 0
        positions[1] = new Vector3(124f, 25f, 0);//Right = 1
        positions[2] = new Vector3(100f, 45f, 0);//Up = 2

        sequence = new Vector3[4];
        sequence[0] = positions[0];
        sequence[1] = positions[2];
        sequence[2] = positions[1];
        sequence[3] = positions[2];

        velocities = new Vector2[3];
        velocities[0] = new Vector2(speed, 0);
        velocities[1] = new Vector2(-1f * speed, 0);
        velocities[2] = new Vector2(0, -1f * speed);

        vel_seq = new Vector2[4];
        vel_seq[0] = velocities[0];
        vel_seq[1] = velocities[2];
        vel_seq[2] = velocities[1];
        vel_seq[3] = velocities[2];
    }



    void OnEnable() {
        step = FinalRitual.Instance.GetStep();
        round = FinalRitual.Instance.GetRound();
        float multiplier = 1f + (0.5f * (round - 1));
        transform.position = sequence[step];
        rb.velocity = vel_seq[step] * multiplier;

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Range")) {
            inRange = true;
            //can now be attacked
//            Debug.Log("check for attack");
        }
    }

    void StartRitual() {
        //Get vel from FinalRitual
        //Get pos from FinalRitual
    }
}