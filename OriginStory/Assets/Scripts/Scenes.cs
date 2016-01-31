using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//Add fade to black
//Add delay to restart
//Add checkpoint at Final Platform
public class Scenes : Singleton<Scenes> {
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}