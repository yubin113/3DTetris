using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tetromino3 : MonoBehaviour
{
    float prevTime;
    float fallTime = 1.4f;

 
    void Start()
    {
        //ButtonInputs.instance.SetActiveBlock(gameObject, this);
        //fallTime = GameManager.instance.ReadFallSpeed();
        if (!CheckValidMove())
        {
            //GameManager.instance.SetGameIsOver();
            //FindObjectOfType<AudioManager>().Play("GameOver");
        }
    }
    void Update()
    {
        if(Time.time - prevTime > fallTime)
        {
            transform.position += Vector3.down;


            if (!CheckValidMove())
            {
                transform.position += Vector3.up;
                //DELETE LAYER IF POSSIBLE
                PlayField3.instance.DeleteLayer();
                enabled = false;
                //CREATE A NEW TETRIS BLOCK
                PlayField3.instance.SpawnNewBlock();

                // if (!GameManager.instance.ReadGameIsOver())
                // {
                //     FindObjectOfType<AudioManager>().Play("Impact");
                //     PlayField.instance.SpawnNewBlock();
                //     PlayField.instance.SpawnNewBlock();

                // }
            }
            else
            {
                //UPDATE THE GRID
                PlayField3.instance.UpdateGrid(this);
            }
            prevTime = Time.time;
        }

        //Movement with buttons-----------------------
        if (Input.GetKeyDown(KeyCode.G))
        {
            setInput(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            setInput(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            setInput(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            setInput(Vector3.back);
        }


        //X Rotation----------------------------------
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            setRotationInput(new Vector3(90, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            setRotationInput(new Vector3(-90, 0, 0));
        }


        //Y Rotation-----------------------------------
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            setRotationInput(new Vector3(0, 90, 0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            setRotationInput(new Vector3(0, -90, 0));
        }


        //Z Rotation--------------------------------------
        if (Input.GetKeyDown(KeyCode.O))
        {
            setRotationInput(new Vector3(0, 0, 90));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            setRotationInput(new Vector3(0, 0, -90));
        }

        //스페이스 누르는 동안 속도 증가
        if(Input.GetKeyDown(KeyCode.M)){
            SetSpeed();
        }
        if(Input.GetKeyUp(KeyCode.M)){
            fallTime = 1.4f;
        }

    }

    public void setInput(Vector3 direction)
    {
        transform.position += direction;
        if(!CheckValidMove())
        {
            transform.position -= direction;
        }
        else
        {
            PlayField3.instance.UpdateGrid(this);
            // FindObjectOfType<AudioManager>().Play("Turn");
        }
    }

    public void setRotationInput(Vector3 rotation)
    {
        transform.Rotate(rotation,Space.World);
        if (!CheckValidMove())
        {
            transform.Rotate(-rotation, Space.World);
        }
        else
        {
            PlayField3.instance.UpdateGrid(this);
            // FindObjectOfType<AudioManager>().Play("Turn");
        }
    }

    public bool CheckValidMove()
    {
        foreach(Transform child in transform)
        {
            Vector3 pos = PlayField3.instance.Round(child.position);
            if(!PlayField3.instance.CheckInsideGrid(pos))
            {
                return false;
            }
        }

        foreach(Transform child in transform)
        {
            Vector3 pos = PlayField3.instance.Round(child.position);
            Transform t = PlayField3.instance.GetTransformOnGridPos(pos);
            if(t!=null && t.parent != transform)
            {
                return false;
            }
        }
        return true;
    }

        public void SetSpeed()
    {
        fallTime = 0.1f;
    }
}
