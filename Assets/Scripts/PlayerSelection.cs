using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerSelection : MonoBehaviour
{
    private int SelectedBallIndex;

    [Header("List of Balls")]
    [SerializeField] private List<BallSelectObject> BallList = new List<BallSelectObject>(); 

   [Header("UI References")]
   [SerializeField] private Text BallName;
   [SerializeField] private Image BallImage;

    private void start()
    {
        UpdateCharacterSelection();
    }

    public void previous()
    {
        SelectedBallIndex--;
        if (SelectedBallIndex < 0)
            SelectedBallIndex = BallList.Count - 1;

        UpdateCharacterSelection();
    }

    public void next()
    {
        SelectedBallIndex++;
        if (SelectedBallIndex == BallList.Count)
            SelectedBallIndex = 0;

        UpdateCharacterSelection();
    }

    private void UpdateCharacterSelection()
    {
        BallImage.sprite = BallList[SelectedBallIndex].splash;
        BallName.text = BallList[SelectedBallIndex].ballName;
    }

    public void confirm()
    {
        Debug.Log(string.Format("character {0}:{1} chosen", SelectedBallIndex, BallList[SelectedBallIndex].ballName));
        PlayerPrefs.SetInt("SelectedColor", SelectedBallIndex);
        SceneManager.LoadScene(0);
    }

   
   [System.Serializable]
   public class BallSelectObject
   {
        public Sprite splash;
        public string ballName; 
   }

}
