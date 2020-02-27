using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene(5);
    }

    public void retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel", 0));
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(3);
    }
    
    public void PlayerSelection()
    {
        SceneManager.LoadScene(4);
    }
}
