using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void quit()
    {
        Debug.Log("Back to Menu");
        SceneManager.LoadScene(0);
    }

    public void Again()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel", 0));
    }
}
