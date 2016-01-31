using UnityEngine;
using System.Collections;

public class CheckPoint : Singleton<CheckPoint> {
    public bool saved;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}