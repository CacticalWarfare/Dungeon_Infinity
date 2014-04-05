using UnityEngine;
using System.Collections;
using System;

public class Square : MonoBehaviour
{

    public float x = 0;
    public float y = 0;
    private bool hasBeenChecked;
    private GameObject tile;
    public Sprite sprite;
    private int id;

    public Square(float x, float y, GameObject gridSpace, float scale, Sprite sprite, int id)
    {
        this.x = x;
        this.y = y;
        this.sprite = sprite;
        hasBeenChecked = false;
        this.id = id;

        tile = gridSpace;
        tile.GetComponent<SpriteRenderer>().sprite = sprite;
        tile.transform.localScale = new Vector3(scale, scale, 1);
        Point p = rotateXAxis(x, y, tile);

        Instantiate(tile, new Vector3(p.getX(), p.getY(), 0), Quaternion.Euler(60, 0, 45));
    }

    private void changeSprite(String sprite)
    {
        
    }

    public bool check()
    {
        if (!hasBeenChecked)
        {
            hasBeenChecked = true;
            return false;
        }
        return hasBeenChecked;
    }

    private Point rotateXAxis(float x, float y, GameObject tile)
    {
        
        float newX = (float) ((tile.renderer.bounds.size.x * x + tile.renderer.bounds.size.y * y) * Math.Sqrt(3)/2);//(float)(tile.renderer.bounds.size.x * x * Math.Sqrt(2)) + (float)(tile.renderer.bounds.size.y * y / Math.Sqrt(2));
        float newY =(float) ((tile.renderer.bounds.size.y * y - tile.renderer.bounds.size.x * x) / 2);//(float)(tile.renderer.bounds.size.y * y / 2.85);

        return new Point(newX, newY);
    }

    private void checkNeighbors()
    {


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
