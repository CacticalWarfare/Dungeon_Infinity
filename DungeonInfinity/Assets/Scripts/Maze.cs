using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {

public GameObject Square;

	// Use this for initialization
	void Start () {
        int width = WorldData.WIDTH;
        int height = WorldData.HEIGHT;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++) //(int j = -(height + i - 1); j < height - i + 1; j++)
            {
                Debug.Log(i + ": " + j);
                int id = 0;
                if (i == 0)//|| j == height - i - 1 || i == 0 || i == width)
                {
                    id = 1;
                }
                new Square(i, j, Square, 1,id);
            }
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
