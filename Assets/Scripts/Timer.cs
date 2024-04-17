using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // 타이머를 표시할 UI Text 컴포넌트
    private float startTime; // 타이머 시작 시간

    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (!GameManager.instance.IsGameClear()) // 게임이 클리어되지 않았다면
        {
            float t = Time.time - startTime; // 경과 시간 계산

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2"); // 소수 둘째자리까지 표시

            timerText.text = minutes + ":" + seconds; // 타이머 텍스트 업데이트
        }
    }
}