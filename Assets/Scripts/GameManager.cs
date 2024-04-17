using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score;
    int levels;
    int layersCleared;
    int playtime;
    int highScore;

    bool gameIsOver;
    public bool gameIsClear = false;


    float fallSpeed;

    public bool isSpecialModeActive = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayerPrefs.GetInt("High Score", highScore);
    }

   
   public float ReadFallSpeed()
    {
        return fallSpeed;
    }

  
    public bool ReadGameIsOver()
    {
        return gameIsOver;
    }

    public void SetGameIsOver()
    {
        gameIsOver = true;

        UIHandler.instance.ActivateGameOverWindow();
    }
    public bool ReadGameIsClear()
    {
        return gameIsClear;
    }

    public void SetGameIsClear()
    {
        gameIsClear = true;

        UIHandler.instance.ActivateGameClearWindow();
    }
    public bool IsGameClear()
    {
        return gameIsClear;
    }
    public void ResetGame()
    {
        gameIsClear = false;
        // 다른 게임 상태 관련 변수들도 여기서 초기화
    }

}