using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static float Score { get; set; }
    public static bool is2Jumpable { get; set; }

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
        Debug.Log(Score);
    }

    public static void LoadLevel(int index = 0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
