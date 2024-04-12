using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class PlayField : MonoBehaviour
{

    //물체
    public static PlayField instance;


    //테트리스 공간 크기
    public int gridSizeX, gridSizeY, gridSizeZ;
    [Header("Tetriminos")]
    //블록 집합
    public GameObject[] blockList;
    //고스트 집합(추후 추가)
    public GameObject[] ghostList;
    
    //바닥
    [Header("Playfield Visuals")]
    public GameObject bottomPlane;
    //측면, 윗면
    public GameObject N, S, W, E;

    //블록 랜덤 변수
    int randomIndex;

    //3차원 배열 공간
    public Transform[,,] theGrid;


    void Awake()
    {
        //인스턴스
        instance = this;
    }

    private void Start()
    {
        //3차원 배열 크기로 생성
        theGrid = new Transform[gridSizeX, gridSizeY, gridSizeZ];
        //랜덤 변수 초기화
        CalculatePreview();
        //블록 초기 위치 설정, calculatePreview()가 반복되어져 있는데 삭제해도 될듯?
        SpawnNewBlock();
    }

    //반올림 함수
    public Vector3 Round(Vector3 vec)
    {
        return new Vector3(Mathf.RoundToInt(vec.x),
                            Mathf.RoundToInt(vec.y),
                             Mathf.RoundToInt(vec.z));
    }

    //현재 위치가 공간안인지 체크
    public bool CheckInsideGrid(Vector3 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridSizeX &&
                (int)pos.z >= 0 && (int)pos.z < gridSizeZ &&
                (int)pos.y >= 0); 
    }

    public void UpdateGrid(Tetromino block)
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                for(int y = 0; y < gridSizeY; y++)
                {
                    if(theGrid[x,y,z]!=null)
                    {
                        if (theGrid[x, y, z].parent == block.transform)
                        {
                            theGrid[x, y, z] = null;
                        }
                    }
                }
            }
        }

        foreach(Transform child in block.transform)
        {
            Vector3 pos = Round(child.position);
            if(pos.y < gridSizeY)
            {
                theGrid[(int)pos.x, (int)pos.y, (int)pos.z] = child;
            }
        }
    }
    public Transform GetTransformOnGridPos(Vector3 pos)
    {
        if(pos.y > gridSizeY - 1)
        {
            return null;
        }
        else
        {
            return theGrid[(int)pos.x, (int)pos.y, (int)pos.z];
        }
    }

    public void SpawnNewBlock()
    {
        //블록 초기 위치 설정
        Vector3 spawnPoint = new Vector3((int)(transform.position.x + (float)gridSizeX / 2),
                                         (int)transform.position.y + gridSizeY,
                                         (int)(transform.position.z + (float)gridSizeZ / 2));


        //Spawn The Block
        GameObject tempBlock = Instantiate(blockList[randomIndex], spawnPoint, Quaternion.identity)as GameObject;
        //Ghost
        //GameObject newGhost = Instantiate(ghostList[randomIndex], spawnPoint, Quaternion.identity) as GameObject;
        Tetromino tetromino = tempBlock.GetComponent<Tetromino>();

        // Check if the spawn position is valid

        // 블록 생성기 위치까지 도달 시 동작 중단, 블록 2종류 이상 사용 시 동작
        if (!tetromino.CheckValidMove())
        {
            // If not, destroy the temporary block and stop spawning
            Destroy(tempBlock);
            Debug.Log("Game Over");
            return;
        }

        // If the spawn position is valid, continue with the game
        //Spawn The Block
        GameObject newBlock = tempBlock;

        CalculatePreview();
    }

    public void CalculatePreview()
    {
        //블록 랜덤 변수 초기화
        randomIndex = Random.Range(0, blockList.Length);
    }

    public void DeleteLayer()
    {
        int layersCleared = 0;
        for(int y = gridSizeY-1; y >= 0; y--)
        {
            //Check full Layer
            if (CheckFullLayer(y))
            {
                layersCleared++;
                //Delete some blocks
                DeleteLayerAt(y);
                MoveAllLayerDown(y);
                //Move all Down By 1
            }
        }
        if(layersCleared > 0)
        {
        }
    }

    bool CheckFullLayer(int y)
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                if(theGrid[x,y,z] == null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void DeleteLayerAt(int y)
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Destroy(theGrid[x, y, z].gameObject);

                theGrid[x, y, z] = null;
            }
        }
    }

    void MoveAllLayerDown(int y)
    {
        for (int i = y; i < gridSizeY; i++)
        {
            MoveOneLayerDown(i);
        }
    }

    
    void MoveOneLayerDown(int y)
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                if(theGrid[x,y,z] != null)
                {
                    theGrid[x, y - 1, z] = theGrid[x, y, z];
                    theGrid[x, y, z] = null;
                    theGrid[x, y - 1, z].position += Vector3.down;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if(bottomPlane != null)
        {
            //RESIZE BOTTOM PLANE
            Vector3 scaler = new Vector3((float)gridSizeX/10, 1, (float)gridSizeZ / 10);
            bottomPlane.transform.localScale = scaler;

            //REPOSITION
            bottomPlane.transform.position = new Vector3(transform.position.x + (float)gridSizeX/2,
                                                         transform.position.y,
                                                         transform.position.z + (float)gridSizeZ/2);

            //RETILE MATERIAL
            bottomPlane.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeZ);
        }

        if (N != null)
        {
            //RESIZE BOTTOM PLANE
            Vector3 scaler = new Vector3((float)gridSizeX / 10, 1, (float)gridSizeY / 10);
            N.transform.localScale = scaler;

            //REPOSITION
            N.transform.position = new Vector3(transform.position.x + (float)gridSizeX / 2,
                                                         transform.position.y +(float)gridSizeY/2,
                                                         transform.position.z + gridSizeZ);

            //RETILE MATERIAL
            N.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeY);
        }

        if (S != null)
        {
            //RESIZE BOTTOM PLANE
            Vector3 scaler = new Vector3((float)gridSizeX / 10, 1, (float)gridSizeY / 10);
            S.transform.localScale = scaler;

            //REPOSITION
            S.transform.position = new Vector3(transform.position.x + (float)gridSizeX / 2,
                                                         transform.position.y + (float)gridSizeY / 2,
                                                         transform.position.z);

            //RETILE MATERIAL
            //S.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeX, gridSizeY);
        }


        if (E != null)
        {
            //RESIZE BOTTOM PLANE
            Vector3 scaler = new Vector3((float)gridSizeZ / 10, 1, (float)gridSizeY / 10);
            E.transform.localScale = scaler;

            //REPOSITION
            E.transform.position = new Vector3(transform.position.x + gridSizeX,
                                                         transform.position.y + (float)gridSizeY / 2,
                                                         transform.position.z + (float)gridSizeZ/2);

            //RETILE MATERIAL
            E.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeZ, gridSizeY);
        }

        if (W != null)
        {
            //RESIZE BOTTOM PLANE
            Vector3 scaler = new Vector3((float)gridSizeZ / 10, 1, (float)gridSizeY / 10);
            W.transform.localScale = scaler;

            //REPOSITION
            W.transform.position = new Vector3(transform.position.x,
                                                         transform.position.y + (float)gridSizeY / 2,
                                                         transform.position.z + (float)gridSizeZ / 2);

            //RETILE MATERIAL
            //W.GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(gridSizeZ, gridSizeY);
        }

    }
}
