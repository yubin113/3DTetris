using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // 타이머를 표시할 UI Text 컴포넌트
    public TMP_Text clearTimeText; // 클리어 시간을 표시할 UI Text 컴포넌트
    private float startTime; // 타이머 시작 시간

    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (GameManager.instance.isSpecialModeActive && !GameManager.instance.IsGameClear() && !GameManager.instance.IsGameOver())
        {
            float elapsedTime = Time.time - startTime; // 경과 시간 계산

            string elapsedMinutes = ((int)elapsedTime / 60).ToString();
            string elapsedSeconds = (elapsedTime % 60).ToString("f2"); // 소수 둘째자리까지 표시

            timerText.text = elapsedMinutes + ":" + elapsedSeconds; // 타이머 텍스트 업데이트
        }
        else
        {
            timerText.text = ""; // 특별 모드가 아니라면 타이머 텍스트를 비움
        }
    }
}