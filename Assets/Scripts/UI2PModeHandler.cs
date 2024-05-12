using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI2PModeHandler : MonoBehaviour
{
    public static UI2PModeHandler instance;

    public GameObject gameOverWindow;
    public TextMeshProUGUI textMeshPro;

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverWindow.SetActive(false);
    }

    public void ActivateGameOverWindow(String s){
        //gameOverWindow.GetComponent<TextMeshPro>().text = s;
        textMeshPro.text = s;
        gameOverWindow.SetActive(true);
        
    }

}
