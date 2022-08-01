using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallState
{
    // 0 0 0 0 => no walls
    // 1 1 1 1 => all walls
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8,
    VISITED = 128
}

public struct Position
{
    public int x;
    public int y;
}

public struct Neighbour
{
    public Position position;
    public WallState sharedWall;
}

public static class MazeGenerator
{
    private static WallState GetOppositeWall(WallState wall)
    {
        switch(wall)
        {
            case WallState.RIGHT:
                return WallState.LEFT;
            case WallState.LEFT:
                return WallState.RIGHT;
            case WallState.UP:
                return WallState.DOWN;
            case WallState.DOWN:
                return WallState.UP;
            default:
                return WallState.LEFT;
        }
    }

    private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int w, int h)
    {
        var random = new System.Random();
        var positionStack = new Stack<Position>();
        var position = new Position{x = random.Next(0,w), y = random.Next(0,h)};

        maze[position.x, position.y] |= WallState.VISITED;
        positionStack.Push(position);

        while(positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var neighbours = GetUnvisitedNeighbours(current, maze, w, h);

            if(neighbours.Count > 0)
            {
                positionStack.Push(current);
                var randNext = random.Next(0, neighbours.Count);
                var randomNeighbour = neighbours[randNext];

                var nPosition = randomNeighbour.position;
                maze[current.x, current.y] &= ~randomNeighbour.sharedWall;
                maze[nPosition.x, nPosition.y] &= ~GetOppositeWall(randomNeighbour.sharedWall);

                maze[nPosition.x, nPosition.y] |= WallState.VISITED;

                positionStack.Push(nPosition);
            }
        }

        int n = random.Next(0, 600);
        if(n < 101){
            maze[w-1,0] &= ~WallState.DOWN;
        }
        else if(n < 201){
            maze[w-1,0] &= ~WallState.RIGHT;
        }
        else if(n < 301){
            maze[0, h-1] &= ~WallState.UP;
        }
        else if(n < 401){
            maze[0, h-1] &= ~WallState.LEFT;
        }
        else if(n < 501){
            maze[w-1, h-1] &= ~WallState.RIGHT;
        }
        else{
            maze[w-1, h-1] &= ~WallState.UP;
        }
            

        return maze;
    }

    public static List<Neighbour> GetUnvisitedNeighbours(Position p, WallState[,] maze, int w, int h)
    {
        var list = new List<Neighbour>();

        if (p.x > 0) // LEFT
        {
            if (!maze[p.x - 1, p.y].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    position = new Position
                    {
                        x = p.x - 1,
                        y = p.y
                    },
                    sharedWall = WallState.LEFT
                });
            }
        }

        if (p.y > 0) // DOWN
        {
            if (!maze[p.x, p.y - 1].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    position = new Position
                    {
                        x = p.x,
                        y = p.y - 1
                    },
                    sharedWall = WallState.DOWN
                });
            }
        }

        if (p.y < h - 1) // UP
        {
            if (!maze[p.x, p.y + 1].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    position = new Position
                    {
                        x = p.x,
                        y = p.y + 1
                    },
                    sharedWall = WallState.UP
                });
            }
        }

        if (p.x < w - 1) // RIGHT & ok
        {
            if (!maze[p.x + 1, p.y].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    position = new Position
                    {
                        x = p.x + 1,
                        y = p.y
                    },
                    sharedWall = WallState.RIGHT
                });
            }
        }

        return list;
    }

    public static WallState[,] Generate(int w, int h)
    {
        WallState[,] maze = new WallState[w,h];
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN;

        for(int i = 0; i < w; i++)
            for(int j = 0; j < h; j++)
                maze[i,j] = initial; // All = 1111

        return ApplyRecursiveBacktracker(maze, w, h);
    }
}
