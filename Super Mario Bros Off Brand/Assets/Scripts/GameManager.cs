using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static float Score { get; set; }
    public static bool is2Jumpable { get; set; }
    private static Text scoreText { get; set; }
    private void Awake()
    {
        Instance = this;
        Score = 0;
        is2Jumpable = false;
        DontDestroyOnLoad(Instance);
    }

    public static void IncrementScore()
    {
        Score = Score + 50;
    }

    public static void LoadLevel(int index = 0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    public static void PrintScore() {
        GameObject score = GameObject.FindWithTag("Score");
        scoreText = score.GetComponent<Text>();
        scoreText.text = "Score: " + GameManager.Score;
    }
}
