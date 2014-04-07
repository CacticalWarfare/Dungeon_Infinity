using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {

public Sprite gridSpace;
public Sprite edgeSpace;
public GameObject grid;
//private Square[,] array new Square[,];

	// Use this for initialization
	void Start () {
        int width = WorldData.WIDTH;
        int height = WorldData.HEIGHT;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++) //(int j = -(height + i - 1); j < height - i + 1; j++)
            {
                if (i == 0 || i == width - 1 || j  == 0 || j == height -1)//|| j == height - i - 1 || i == 0 || i == width)
                {
                    WorldData.grid[i,j] = new Square(i, j, grid, 1, edgeSpace,1);
                }
                else
                {
                    WorldData.grid[i, j] = new Square(i, j, grid, 1, gridSpace, 0);

                }
            }
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
