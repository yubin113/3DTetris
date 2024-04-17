using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public string SampleScene;
    public string MainMenu;
    public string SamSam;
    public void StartGame()
    {
       SceneManager.LoadScene("SampleScene");
    }
    public void GotoMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartMode()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.instance.isSpecialModeActive = true;
    }
}
