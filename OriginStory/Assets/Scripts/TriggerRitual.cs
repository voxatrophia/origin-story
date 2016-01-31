using UnityEngine;
using System.Collections;

public class TriggerRitual : MonoBehaviour {
    public GameObject player;
    Praying pray_script;
    Ritual rit_script;
    public GameObject group;

    void Awake() {
        pray_script = player.GetComponent<Praying>();
        rit_script = player.GetComponent<Ritual>();
        group.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            pray_script.enabled = false;
            rit_script.enabled = true;
            group.SetActive(true);
        }
    }
}