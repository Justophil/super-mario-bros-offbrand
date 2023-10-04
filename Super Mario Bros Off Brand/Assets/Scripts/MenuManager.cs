using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start() {
        if(SceneManager.GetActiveScene().name == "End") {
            GameManager.PrintScore();
        }
    }
    public void OnGameStart() {
        GameManager.Score = 0;
        SceneManager.LoadScene("Level1");
    }

    public void OnGameExit() {
        Application.Quit();
    }
}
