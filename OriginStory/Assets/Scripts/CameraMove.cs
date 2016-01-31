using UnityEngine;
using System.Collections;

public class CameraMove : Singleton<CameraMove> {
    public Vector3[] positions;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    public int pos = 0;

    void Awake() {
        if (CheckPoint.Instance.saved) {
            pos = 4;
        }
    }

    void OnEnable() {
        EventManager.StartListening("FirstCameraTrigger", MoveCamera);
    }

    void OnDisable() {
        EventManager.StopListening("FirstCameraTrigger", MoveCamera);
    }

    void Update() {
        if (transform.position != positions[pos]) {

            Vector3 targetPosition = positions[pos];
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    void MoveCamera() {
        ////Vector3 targetPosition = new Vector3(0, 5, -10);
        //Vector3 targetPosition = transform.TransformPoint(positions[0]);
        //Debug.Log(targetPosition);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}