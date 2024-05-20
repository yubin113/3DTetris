using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI2PModeHandler : MonoBehaviour
{
    public static UI2PModeHandler instance;

    public GameObject gameOverWindow;
    public GameObject gamePauseWindow;

    public TextMeshProUGUI textMeshPro;
    public GameObject rotateAround;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverWindow.SetActive(false);
        gamePauseWindow.SetActive(false);
    }

    public void ActivateGameOverWindow(String s)
    {
        //gameOverWindow.GetComponent<TextMeshPro>().text = s;
        textMeshPro.text = s;
        gameOverWindow.SetActive(true);
        //게임종료시 카메라 회전 종료되게 만듦
        rotateAround.GetComponent<RotateAround>().enabled = false;
    }
    public void ActivateGamePuaseWindow()
    {
        gamePauseWindow.SetActive(true);
    }
    public void DeactivateGamePuaseWindow()
    {
        gamePauseWindow.SetActive(false);
    }

}
