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
        // ���� ���� �ʱ�ȭ
        GameManager.instance.ResetGame();

        // ���� ��� ��ε�
        SceneManager.LoadScene("PracticeScene");
    }
}
