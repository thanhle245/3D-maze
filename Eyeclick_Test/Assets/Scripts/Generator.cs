using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum Walls{
    LEFT=1, 
    RIGHT=2, 
    TOP=4,  
    DOWN=8, 
    VISITED = 128
}

public struct Position{
    public int X;
    public int Y;
}

public struct Neighbour{
    public Position Position;
    public Walls SharedWall;
}

public static class Generator 
{
    
    private static Walls[,] RecursiveBacktracker(Walls[,] maze, int width, int height){
        //make changes
        var rng = new System.Random();
        var positionStack = new Stack<Position>();
        var position = new Position {X = rng.Next(0,width), Y =rng.Next(0,height)};
        maze[position.X,position.Y] |= Walls.VISITED;
        positionStack.Push(position);

        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var neighbours = GetUnvisitedNeighbour(current,maze, width, height);
            if (neighbours.Count > 0)
            {
                positionStack.Push(current);
                var randIndex =rng.Next(0,neighbours.Count);
                var randomNeighbour = neighbours[randIndex];

                var nPosition = randomNeighbour.Position;
                maze[current.X,current.Y] &= ~ randomNeighbour.SharedWall;
                maze[nPosition.X,nPosition.Y] &= ~ GetOppositeWall(randomNeighbour.SharedWall);
                maze[nPosition.X,nPosition.Y] |= Walls.VISITED;
                positionStack.Push(nPosition);
            }
        }
        return maze;
    }
    private static List<Neighbour> GetUnvisitedNeighbour(Position pos ,Walls[,] maze,int width,int height){
        var list = new List<Neighbour>();
        if (pos.X>0) 
        {
            if (!maze[pos.X-1,pos.Y].HasFlag(Walls.VISITED))
            {
                list.Add(new Neighbour{
                    Position = new Position{
                        X=pos.X-1,
                        Y = pos.Y
                    },
                    SharedWall = Walls.LEFT
                });
            }
        }
        if (pos.Y>0) 
        {
            if (!maze[pos.X,pos.Y -1].HasFlag(Walls.VISITED))
            {
                list.Add(new Neighbour{
                    Position = new Position{
                        X=pos.X,
                        Y=pos.Y -1
                    },
                    SharedWall = Walls.DOWN
                });
            }
        }
        if (pos.Y<height - 1) 
        {
            if (!maze[pos.X,pos.Y+1].HasFlag(Walls.VISITED))
            {
                list.Add(new Neighbour{
                    Position = new Position{
                        X=pos.X,
                        Y=pos.Y + 1
                    },
                    SharedWall = Walls.TOP
                });
            }
        }
        if (pos.X< width - 1) 
        {
            if (!maze[pos.X+1,pos.Y].HasFlag(Walls.VISITED))
            {
                list.Add(new Neighbour{
                    Position = new Position{
                        X=pos.X+1,
                        Y = pos.Y
                    },
                    SharedWall = Walls.RIGHT
                });
            }
        }
        return list;
    }
private static Walls GetOppositeWall(Walls wall){
        switch (wall)
        {
            case Walls.RIGHT:
                return Walls.LEFT;
            case Walls.LEFT:
                return Walls.RIGHT;
            case Walls.TOP:
                return Walls.DOWN;
            case Walls.DOWN:
                return Walls.TOP;
                
            default:
                return Walls.LEFT;
        }
        
    }
    public static Walls[,] Generate(int width, int height){
        Walls[,] maze = new Walls[width,height];
        Walls initial = Walls.LEFT | Walls.RIGHT | Walls.TOP | Walls.DOWN;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                maze[i,j] = initial; //1111
            }
        }
        return RecursiveBacktracker(maze,width, height) ;
    }
}
