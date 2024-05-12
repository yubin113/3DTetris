using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround2 : MonoBehaviour
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
    }

    void OrbitWithArrowKeys()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.Comma))
        {
            horizontalInput = -1f; // 왼쪽 화살표키
        }
        else if (Input.GetKey(KeyCode.Slash))
        {
            horizontalInput = 1f; // 오른쪽 화살표키
        }

        if (Input.GetKey(KeyCode.L))
        {
            verticalInput = 1f; // 위쪽 화살표키
        }
        else if (Input.GetKey(KeyCode.Period))
        {
            verticalInput = -1f; // 아래쪽 화살표키
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
