using UnityEngine;
using System;

public class CharacterController : MonoBehaviour {
	public float maxSpeed = 60f;
	private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;

    private float headToFeetDist = 3f;

    private float ScreenXtoWorld = 1f / 15f;
    private float ScreenYtoWorld = 2f / 35f;

    public Vector3 target;
    public Vector3 goalPosition;

    private static int Z_DISPLACEMENT = -20;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        goalPosition = transform.position;
        target = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y, Z_DISPLACEMENT);
        //if (target != transform.position)
        //{
        //    Vector3 newPosition = Vector3.SmoothDamp(transform.position, target, ref velocity, .5f, maxSpeed);
            
        //    Debug.Log("transform.position: " + transform.position);
        //    Debug.Log("target: " + target);

        //    target -= (newPosition - transform.position);
        //    transform.position = newPosition;

        //    int dist = (int)Vector3.Distance(target, transform.position);
        //    Debug.Log("Distance to other: " + dist);
        //    if(dist == 0)
        //        target = transform.position;
        //}
        
        if (Input.GetButton("Fire1"))
            //Input.GetMouseButtonDown(0))
        {
            float x = (Input.mousePosition.x - Screen.width/2)*ScreenXtoWorld;//transform.localScale.x;
            float y = (Input.mousePosition.y - Screen.height / 2)*ScreenYtoWorld + headToFeetDist;//transform.localScale.y;

            //Debug.Log("x: " + x);
            //Debug.Log("y: " + y);

            //Debug.Log("transform.position.x: " + transform.position.x);
            //Debug.Log("transform.position.y: " + transform.position.y);


            target = new Vector3(x, y, Z_DISPLACEMENT);
            goalPosition = transform.position + target;
            //transform.position = new Vector3(x, y, Z_DISPLACEMENT);
            //Debug.Log("transform.position: " + transform.position);
            //Debug.Log(target);
            //target.z = -20;

            //transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, .5f, 20f);

            if (target.x < 0 && !facingRight)
                flip();
            else if (target.x > 0 && facingRight)
                flip();
        }
        if(transform.position != goalPosition)
            transform.position = Vector3.SmoothDamp(transform.position, goalPosition, ref velocity, .3f, maxSpeed);

        //float moveX = Input.GetAxis("Horizontal");
        //float moveY = Input.GetAxis("Vertical");
        //float move = (float) Math.Sqrt(Math.Pow(moveX, 2) + Math.Pow(moveY,2));

        //anim.SetFloat("Speed", Mathf.Abs(move));

        //rigidbody2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        //if(moveX > 0 && !facingRight) 
        //    flip();
        //else if(moveX < 0 && facingRight)
        //    flip();
		
		
	}
	
	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
