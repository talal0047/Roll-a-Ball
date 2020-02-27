using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

  
    public Text time;
    public Text countText;
    public Text winText;
    public float speed;
    public Transform Player;
    public GameObject pickupEffect;
    private Rigidbody rb;
    private int count;
    private int selectedBall;
    public Color color;
    Renderer rend;

    void Start()
    {
        selectedBall = PlayerPrefs.GetInt("SelectedColor", 1);
        time.text = "";
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        Debug.Log(selectedBall);
        if (selectedBall == 3)  // WHITE Ball
        {
            ChangeColor(241, 243, 241, 255);
        }
        else if (selectedBall == 0) // RED Ball
        {
            ChangeColor(214, 30, 14, 255);
        }
        else if (selectedBall == 1)  // PURPLE Ball
        {
            ChangeColor(228, 23, 215, 122);
        }
        else if (selectedBall == 2)  // BLUE BALL
        {
            ChangeColor(49, 20, 241, 255);
        }

        //gameObject.GetComponent<Renderer>().material.color = new Color(214, 30, 14, 30);
        
    }

    void ChangeColor(float r, float g, float b, float a)
    {
        rend = GetComponent<Renderer>();
        color.g = g / 255f;
        color.r = r / 255f;
        color.b = b / 255f;
        color.a = a / 255f;
        Debug.Log(color);
        rend.material.color = color;
    }

    void FixedUpdate() //call just before performing any physical calculation
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3( moveHorizontal, 0.0f, movevertical);

        Timer();

        if ((int)Player.position.y < -5)
        {
            saving();
            Debug.Log("Y-Down");
            SceneManager.LoadScene(1);
        }

        rb.AddForce(movement * speed);

      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //speed = 2;
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
            PickUpEffect();
        }
        //Destroy(other.gameObject);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 120)
        {
            winText.text = "You Win!";
        }
    }

    void PickUpEffect()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
    }

    void Timer()
    {
        int TimerIncrementer = SceneManager.GetActiveScene().buildIndex - 4;
        double ScoreIncrementer = 1;
        for(int i = 1; i < TimerIncrementer; i++)
        {
            ScoreIncrementer = ScoreIncrementer + 0.25;
        }
        //Debug.Log(Time.timeSinceLevelLoad);
        time.text = "Timer: " + Time.timeSinceLevelLoad.ToString();
        if(Time.timeSinceLevelLoad > 30 * TimerIncrementer && count < 120 * ScoreIncrementer)
        {
            saving();
            SceneManager.LoadScene(1);
        }
        else if(Time.timeSinceLevelLoad < 30 * TimerIncrementer && count >= 120 * ScoreIncrementer)
        {
            //int tempcount = PlayerPrefs.GetInt("TotalScore", 0);
            //tempcount = count + tempcount;
            //PlayerPrefs.SetInt("TotalScore", tempcount);
            //PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
            //PlayerPrefs.SetInt("Count", count);
            saving();
            SceneManager.LoadScene(2);
        }
    }

    public void saving()
    {
        int tempcount = PlayerPrefs.GetInt("TotalScore", 0);
        tempcount = count + tempcount;
        PlayerPrefs.SetInt("TotalScore", tempcount);
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("Count", count);
    }

    public int GetCount()
    {
        return count;
    }
}
