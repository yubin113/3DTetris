using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Ÿ�̸Ӹ� ǥ���� UI Text ������Ʈ
    private float startTime; // Ÿ�̸� ���� �ð�

    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (!GameManager.instance.IsGameClear()) // ������ Ŭ������� �ʾҴٸ�
        {
            float t = Time.time - startTime; // ��� �ð� ���

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2"); // �Ҽ� ��°�ڸ����� ǥ��

            timerText.text = minutes + ":" + seconds; // Ÿ�̸� �ؽ�Ʈ ������Ʈ
        }
    }
}