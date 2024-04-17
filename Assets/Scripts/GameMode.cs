using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    public string SampleScene;
    public string MainMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
 }
