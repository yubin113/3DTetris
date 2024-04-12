using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public static UIHandler instance;
       
    public GameObject gameOverWindow;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOverWindow.SetActive(false);
    }

    
    // public void UpdateHSUI(int highScore)
    //{
    //   highScoreText.text = "High Score: " + highScore.ToString();
    //}

    public void ActivateGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
