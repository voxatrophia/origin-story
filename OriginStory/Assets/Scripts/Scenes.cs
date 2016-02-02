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

    public void GameOver() {
        Time.timeScale = 0;
        Debug.Log("You died");
        Fader.Instance.FadeToBlack();
    }

    public void Victory() {
        Fader.Instance.FadeToBlack();
        //        Time.timeScale = 0;
        NextScene();
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}