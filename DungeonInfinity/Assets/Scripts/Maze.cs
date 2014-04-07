using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {

public Sprite gridSpace;
public Sprite edgeSpace;
public GameObject grid;


	void Start () {
        int width = WorldData.WIDTH;
        int height = WorldData.HEIGHT;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                WorldData.grid[i, j] = new Square(i, j, grid, 1, gridSpace, 0, edgeSpace);
            }
		}
        System.Random rand = new System.Random();
        WorldData.grid[rand.Next(width), rand.Next(height)].makeMaze();

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
