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

    public bool gameIsOver = false;
    public bool gameIsClear = false;

    private float clearTime;

    float fallSpeed;

    public bool isSpecialModeActive = false;

    public bool gameIsPaused = false;

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
    public bool IsGameOver() 
    {
        return gameIsOver;
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
        gameIsOver = false;
        gameIsPaused = false;
        // �ٸ� ���� ���� ���� �����鵵 ���⼭ �ʱ�ȭ
    }
    // Ŭ���� �ð��� �����ϴ� �޼ҵ�
    public void SetClearTime(float time)
    {
        clearTime = time;
    }

    // Ŭ���� �ð��� ��ȯ�ϴ� �޼ҵ�
    public float GetClearTime()
    {
        return clearTime;
    }

    public void SetGameIsPaused(){
        gameIsPaused = true;
        Time.timeScale = 0f;
        UIHandler.instance.ActivateGamePuaseWindow();
    }
    public void SetGameIsResumed(){
        gameIsPaused = false;
        Time.timeScale = 1f;
        UIHandler.instance.DeactivateGamePuaseWindow();
    }
}