using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scenes : Singleton<Scenes> {
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("called");
    }
}