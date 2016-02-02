using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Splash : MonoBehaviour {
    void Start() {
        Invoke("NextScene", 4f);
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
