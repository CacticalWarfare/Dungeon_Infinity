using UnityEngine;
using System.Collections;
using System;

public class Square : MonoBehaviour
{

    public int x = 0;
    public int y = 0;
    private bool hasBeenChecked;
    private bool hasBeenCheckedTwice;
    private bool path = false;
    private GameObject tile;
    private Sprite sprite;
    private int id;
    private float scale;

    public Square(int x, int y, GameObject tile, float scale, Sprite sprite, int id)
    {
        this.x = x;
        this.y = y;
        this.sprite = sprite;
        hasBeenChecked = false;
        hasBeenCheckedTwice = false;
        this.id = id;
        this.tile = tile;
        this.sprite = sprite;
        this.scale = scale;
    }

    public bool isPath()
    {
        return path;
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public void instantiate()
    {
        tile.GetComponent<SpriteRenderer>().sprite = sprite;
        tile.transform.localScale = new Vector3(scale, scale, 1);
        Point p = rotateXAxis(x, y, tile);

        Instantiate(tile, new Vector3(p.getX(), p.getY(), 0), Quaternion.Euler(60, 0, 45));
    }

    private Point rotateXAxis(float x, float y, GameObject tile)
    {

        float newX = (float)((tile.renderer.bounds.size.x * x + tile.renderer.bounds.size.y * y) / Math.Sqrt(2));//(float)(tile.renderer.bounds.size.x * x * Math.Sqrt(2)) + (float)(tile.renderer.bounds.size.y * y / Math.Sqrt(2));
        float newY = (float)((tile.renderer.bounds.size.y * y - tile.renderer.bounds.size.x * x) / 2.85);//(float)(tile.renderer.bounds.size.y * y / 2.85);

        return new Point(newX, newY);
    }

    public void makeMaze()
    {
        path = true;
        hasBeenCheckedTwice = true;
        ArrayList neighbors = getNeighbors();
        System.Random rand = new System.Random(10);
        while (neighbors.Count > 0)
        {
            int i = (int) (rand.NextDouble() * neighbors.Count);
            Square possiblePath = (Square) neighbors[i];
            if (!possiblePath.secondCheck())
            {
                possiblePath.makeMaze();
            }
            else
            {
                neighbors.RemoveAt(i);
            }
        }

    }

    public bool firstCheck()
    {
        if (!hasBeenChecked)
        {
            hasBeenChecked = true;
            return false;
        }
        else
        {
            if (!hasBeenCheckedTwice)
            {
                hasBeenCheckedTwice = true;
            }
        }
        return hasBeenChecked;
    }

    public bool secondCheck()
    {
        return hasBeenCheckedTwice;
    }

    private ArrayList getNeighbors()
    {

        ArrayList neighbors = new ArrayList(); //[NORTH,EAST,SOUTH,WEST]
        if (y < WorldData.HEIGHT - 1)
        {
            if (WorldData.grid[x, y + 1].firstCheck() == false)
            {
                Square temp = WorldData.grid[x, y + 1];
                neighbors.Add(temp);
            }
        }
        if (x < WorldData.WIDTH - 1)
        {
            if (WorldData.grid[x + 1, y].firstCheck() == false)
            {
                Square temp = WorldData.grid[x + 1, y];
                neighbors.Add(temp);
            }
        }
        if (y > 0)
        {
            if (WorldData.grid[x, y - 1].firstCheck() == false)
            {
                Square temp = WorldData.grid[x, y - 1];
                neighbors.Add(temp);
            }
        }
        if (x > 0)
        {
            if (WorldData.grid[x - 1, y].firstCheck() == false)
            {
                Square temp = WorldData.grid[x - 1, y];
                neighbors.Add(temp);
            }
        }

        return neighbors;


    }

    class Point
    {

        float x;
        float y;

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float getX()
        {
            return x;
        }
        public float getY()
        {
            return y;
        }



    }

}
