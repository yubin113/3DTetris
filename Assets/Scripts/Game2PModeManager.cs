using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2PModeManager : MonoBehaviour
{
    public static Game2PModeManager instance;

    public bool leftWin = false;
    public bool rightWin = false;
    public bool gameIsPaused = false;
    
    private void Awake()
    {
        instance = this; //자신을 인스턴스로
    }
    void Start()
    {
        
    }

    public void setLeftWin(){
        leftWin = true;
        if (UI2PModeHandler.instance == null) {
            Debug.LogError("UI2PModeHandler instance is null");
        } else {
            UI2PModeHandler.instance.ActivateGameOverWindow("왼쪽 플레이어 승!");
        }

    }
    public bool getLeftWin(){
        return leftWin;
    }
    public void setRightWin(){
        rightWin = true;
        if (UI2PModeHandler.instance == null) {
            Debug.LogError("UI2PModeHandler instance is null");
        } else {
            UI2PModeHandler.instance.ActivateGameOverWindow("오른쪽 플레이어 승!");
        }
        // UI2PModeHandler.instance.ActivateGameOverWindow();
    }
    public bool getRightWin(){
        return rightWin;
    }
    public void ResetGame(){
        leftWin = false;
        rightWin = false;
        SetGameIsResumed();
    }
    public void SetGameIsPaused(){
        gameIsPaused = true;
        Time.timeScale = 0f;
        UI2PModeHandler.instance.ActivateGamePuaseWindow();
    }
    public void SetGameIsResumed(){
        gameIsPaused = false;
        Time.timeScale = 1f;
        UI2PModeHandler.instance.DeactivateGamePuaseWindow();
    }

}
