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
        SceneManager.LoadScene("Gamemode");
    }
    public void OnRetryButtonClicked()
    {
        // 게임 상태 초기화
        GameManager.instance.ResetGame();

        // 게임 장면 재로드
        SceneManager.LoadScene("PracticeScene");
    }
}
