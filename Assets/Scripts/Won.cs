using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Won : MonoBehaviour
{
    public Text countText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("Count", 0);
        countText.text = "Total Capture: " + count.ToString();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel") + 1);
    }
}
