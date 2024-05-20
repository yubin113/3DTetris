using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround2P : MonoBehaviour
{

    //메인 카메라
    Transform target;
    Transform rotTarget;
    Vector3 lastPos;

    float sensitivity = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        rotTarget = transform.parent;
        target = rotTarget.transform.parent;
    }

    // Update camera frame
    void Update()
    {
        transform.LookAt(target);
        
        OrbitWithArrowKeys();

        //일시정지 기능
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("escape");
            if(Game2PModeManager.instance.gameIsPaused){
                Game2PModeManager.instance.SetGameIsResumed();
            }else{
                Game2PModeManager.instance.SetGameIsPaused();
            }
        }
    }

    void OrbitWithArrowKeys()
    {
        float horizontalInput = 0;
        float verticalInput = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = Input.GetAxis("Vertical");
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            float angleY = horizontalInput * sensitivity;
            float angleX = verticalInput * sensitivity;

        // X AXIS
        Vector3 angles = rotTarget.transform.eulerAngles;
        angles.x += angleX;
        angles.x = ClampAngle(angles.x, -85f, 85f);

        rotTarget.transform.eulerAngles = angles;

        // Y AXIS
        target.RotateAround(target.position, Vector3.up, angleY);
        }
        float ClampAngle(float angle, float from, float to)
        {

            if (angle < 0) angle = 360 + angle;
            if (angle > 180f) return Mathf.Max(angle, 360 + from);

            return Mathf.Min(angle, to);
        }
    }
    
}
