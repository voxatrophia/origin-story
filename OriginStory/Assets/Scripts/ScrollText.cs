using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollText : MonoBehaviour {
    public float scrollspeed;
    bool move = true;

//    public GameObject buttons;

    void Start() {
//        buttons.SetActive(false);
    }

    void Update() {
        if (move) {
            transform.position = new Vector3(transform.position.x, transform.position.y + scrollspeed * Time.deltaTime, transform.position.z);
        }

    }
}
