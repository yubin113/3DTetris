using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public static UIHandler instance;
       
    public GameObject gameOverWindow;
    public GameObject gameClearWindow;
    //일시정지 기능
    public GameObject gamePauseWindow;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOverWindow.SetActive(false);
        gameClearWindow.SetActive(false);
        gamePauseWindow.SetActive(false);
    }

        
    // public void UpdateHSUI(int highScore)
    //{
    //   highScoreText.text = "High Score: " + highScore.ToString();
    //}

    public void ActivateGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

    public void ActivateGameClearWindow()
    {
        gameClearWindow.SetActive(true);
    }
    public void ActivateGamePuaseWindow(){
        gamePauseWindow.SetActive(true);
    }
    public void DeactivateGamePuaseWindow(){
        gamePauseWindow.SetActive(false);
    }
   // public void OnSpecialModeButtonClicked()
  //  {
   //     GameManager.instance.isSpecialModeActive = true;
   // }
}
