using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Ÿ�̸Ӹ� ǥ���� UI Text ������Ʈ
    public TMP_Text clearTimeText; // Ŭ���� �ð��� ǥ���� UI Text ������Ʈ
    private float startTime; // Ÿ�̸� ���� �ð�

    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (GameManager.instance.isSpecialModeActive && !GameManager.instance.IsGameClear() && !GameManager.instance.IsGameOver())
        {
            float elapsedTime = Time.time - startTime; // ��� �ð� ���

            string elapsedMinutes = ((int)elapsedTime / 60).ToString();
            string elapsedSeconds = (elapsedTime % 60).ToString("f2"); // �Ҽ� ��°�ڸ����� ǥ��

            timerText.text = elapsedMinutes + ":" + elapsedSeconds; // Ÿ�̸� �ؽ�Ʈ ������Ʈ
        }
        else
        {
            timerText.text = ""; // Ư�� ��尡 �ƴ϶�� Ÿ�̸� �ؽ�Ʈ�� ���
        }
    }
}