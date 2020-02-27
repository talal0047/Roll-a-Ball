using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void selector(int levelName)
    {
        SceneManager.LoadScene(levelName + 4);
    }
}
