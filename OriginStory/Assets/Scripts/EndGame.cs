using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour {
    public void RestartGame() {
        SceneManager.LoadScene("Main");
    }

    public void Quit() {
        AppHelper.Quit();
    }
}
