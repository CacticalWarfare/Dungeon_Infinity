using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {

public Sprite wallSprite;
public Sprite pathSprite;
public Sprite startSprite;
public GameObject grid;


	void Start () {
        int width = WorldData.WIDTH;
        int height = WorldData.HEIGHT;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                WorldData.grid[i, j] = new Square(i, j, grid, 1, wallSprite, 0);
            }
		}
        System.Random rand = new System.Random();
        int startX = rand.Next(width);
        int startY = rand.Next(height);
        WorldData.grid[startX, startY].makeMaze();
        WorldData.grid[startX, startY].setSprite(startSprite);


        //Make more efficient
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (WorldData.grid[i, j].isPath())
                {
                    WorldData.grid[i, j].setSprite(pathSprite);
                }
            }
        }

        WorldData.grid[startX, startY].setSprite(startSprite);


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                    WorldData.grid[i, j].instantiate();
            }
        }



	}


	
	void Update () {
		
	}
}
