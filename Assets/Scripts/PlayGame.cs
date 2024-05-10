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
        // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½Ê±ï¿½È­
        GameManager.instance.ResetGame();

        // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿? ï¿½ï¿½Îµï¿?
        SceneManager.LoadScene("PracticeScene");
    }
    public void twoPlayersMode(){
        SceneManager.LoadScene("2PGameScene");
    }
    public void twoPModeOnRetryButtonClicked(){
        Game2PModeManager.instance.ResetGame();
        SceneManager.LoadScene("2PGameScene");
    }
}
