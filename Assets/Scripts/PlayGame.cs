using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public string PracticeScene;
    public string MainMenu;
   
    public void StartGame()
    {
       SceneManager.LoadScene("PracticeScene");
    }
    public void GotoMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartMode()
    {
        SceneManager.LoadScene("PracticeScene");
        GameManager.instance.isSpecialModeActive = true;
    }
    public void GameModerMenu()
    {
        GameManager.instance.ResetGame();
        GameManager.instance.SetGameIsResumed();
        SceneManager.LoadScene("Gamemode");
    }
    public void OnRetryButtonClicked()
    {
        // ���� ���� �ʱ�ȭ
        GameManager.instance.ResetGame();

        // ���� ���? ��ε�?
        SceneManager.LoadScene("PracticeScene");
    }
    public void IsResume(){
        GameManager.instance.SetGameIsResumed();
    }
    public void IsRetryWhenPause(){
        SceneManager.LoadScene("PracticeScene");
        GameManager.instance.SetGameIsResumed();
    }
    public void twoPlayersMode(){
        SceneManager.LoadScene("2PGameScene");
    }
    public void twoPModeOnRetryButtonClicked(){
        Game2PModeManager.instance.ResetGame();
        SceneManager.LoadScene("2PGameScene");
    }
    public void twoPlayersModePause(){
        Game2PModeManager.instance.SetGameIsPaused();
    }
    public void twoPlayersModeResume(){
        Game2PModeManager.instance.SetGameIsResumed();
    }
    public void twoPlayerModeBackToHome()
    {
        Game2PModeManager.instance.SetGameIsResumed();
        SceneManager.LoadScene("Gamemode");
    }

}
