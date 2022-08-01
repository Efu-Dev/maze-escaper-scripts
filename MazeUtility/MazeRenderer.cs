using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [Range(1,50)]
    public uint width = 20;

    [Range(1,50)]
    public uint height = 20;

    public float size = 0.5f;

    public Transform wallPrefab = null;
    public Timer timer;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate((int)width, (int)height);
        DrawMaze(maze);
        timer.timeLeft = 600;
        timer.timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawMaze(WallState[,] maze)
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                var cell = maze[i,j];
                var position = new Vector3(-width/2 + i*3, 0, -height/2 + j*3);

                if(cell.HasFlag(WallState.LEFT))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0,0,size/2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }
                else if(i == 0)
                {
                    door.transform.position = new Vector3(-6.54f,-0.4f,32.6f);
                    door.transform.eulerAngles = new Vector3(0,90,0);
                }

                if(cell.HasFlag(WallState.UP))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size/2 + 5,0,-2.1f);
                    leftWall.eulerAngles = new Vector3(0,90,0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                }
                else if(j == height - 1 && i == 0)
                {
                    door.transform.position = new Vector3(-7.02f,-0.4f,36.3f);
                }
                else if(j == height - 1)
                {
                    door.transform.position = new Vector3(34.96f,-0.4f,35.6f);
                }

                if(i == width - 1)
                {
                    if(cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(width/2 - width/3.9f,0,0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                    }
                    else if(j == height - 1)
                    {
                        door.transform.position = new Vector3(41.05f,-0.4f,32.53f);
                        door.transform.eulerAngles = new Vector3(0,90,0);
                    }
                    else if(j == 0)
                    {
                        door.transform.position = new Vector3(41.05f,-0.4f,-8.11f);
                        door.transform.eulerAngles = new Vector3(0,90,0);
                    }
                }

                if(j == 0)
                {
                    if(cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(5f,0,-height/2 + height/6f);
                        bottomWall.eulerAngles = new Vector3(0,90,0);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                    else
                    {
                        door.transform.position = new Vector3(35.12f,-0.4f,-11.87f);
                    }
                }
            }
        }
    }
}
