using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;
    private int selectedButtonIndex = 0;

    void Start()
    {
        // 시작할 때 첫 번째 버튼을 선택 상태
        buttons[selectedButtonIndex].Select();
    }

    void Update()
    {
        // 좌우버튼으로 선택 상태 변경
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 좌우 화살표 키가 눌렸을 때 인덱스 변경
            int direction = Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : 1;
            selectedButtonIndex = (selectedButtonIndex + direction + buttons.Length) % buttons.Length;
            buttons[selectedButtonIndex].Select();
        }

        // 위아래버튼으로 선택 상태 변경
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 위아래 화살표 키가 눌렸을 때 인덱스 변경
            int direction = Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1;
            selectedButtonIndex = (selectedButtonIndex + direction + buttons.Length) % buttons.Length;
            buttons[selectedButtonIndex].Select();  
        }

        // Enter키로 onclick 실행
        //근데 스페이스 버튼으로 실행되긴 합니다.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedButtonIndex].onClick.Invoke();
        }
    }
}
