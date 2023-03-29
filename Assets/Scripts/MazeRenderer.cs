﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    private int width = 8;
    [SerializeField]
    private int height = 8;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;
    
    void Start()
    {
        var maze = Generator.Generate(width,height);
        Draw(maze);
    }
    void Draw(Walls[,] maze){
        

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cell = maze[i,j];
                var position = new Vector3((-width/2)+i,0,(-height/2)+j);
                if (cell.HasFlag(Walls.TOP))
                {
                    var topWall = Instantiate(wallPrefab,transform) as Transform;
                    topWall.position = position + new Vector3(0,0,size/2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }
                if (cell.HasFlag(Walls.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab,transform) as Transform;
                    leftWall.position = position + new Vector3(-size/2,0,0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0,90,0);

                }
                if (i == width -1)
                {
                    if(cell.HasFlag(Walls.RIGHT)){
                        var rightWall = Instantiate(wallPrefab,transform) as Transform;
                        rightWall.position = position + new Vector3(size/2,0,0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0,90,0);
                    }
                }
                if (j == 0)
                {
                    if(cell.HasFlag(Walls.DOWN)){
                        var bottomWall = Instantiate(wallPrefab,transform) as Transform;
                        bottomWall.position = position + new Vector3(0,0,-size/2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
