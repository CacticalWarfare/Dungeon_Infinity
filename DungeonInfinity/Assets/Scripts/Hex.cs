using UnityEngine;
using System.Collections;
using System;

public class Hex : MonoBehaviour {

	private float x;
	private float y;
	private bool hasBeenChecked;
	private GameObject tile;
	
	public Hex(float x, float y,GameObject gridSpace){
		this.x = x;
		this.y = y;
		hasBeenChecked = false;
		Point p = rotateXAxis(x,y,.9f,3.5f);
		x = p.getX();
		y = p.getY();
		tile = (GameObject) Instantiate(gridSpace, new Vector3(x,y,0),Quaternion.Euler(45,0,45));
	}
	
	public bool check(){
		if(!hasBeenChecked){
			hasBeenChecked = true;
			return false;
		}
        return hasBeenChecked;
	}
	
	private Point rotateXAxis(float x, float y,float xScale, float yScale){
		if(x < 0){
			yScale *= -1;
		}
		float distance = (float) Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));
		float newX = (float) (distance * xScale * Math.Cos(Math.PI/60));
		float newY = (float) (distance * yScale * Math.Sin(Math.PI/60));
		if(x != 0){
			newX = newX * x/Math.Abs(x);
		}
//		if(y != 0){
//			newY = newY * x/Math.Abs(x);
//		}

		return new Point(newX, newY);
	}
	
	private void checkNeighbors(){
		
		
	}
	
	class Point {
		
		float x;
		float y;
		
		public Point(float x, float y){
			this.x = x;
			this.y = y;
		}
		
		public float getX(){
			return x;
		}
		public float getY(){
			return y;
		}
	
	
	
	}
	
}
