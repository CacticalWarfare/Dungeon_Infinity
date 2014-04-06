using UnityEngine;
using System;

public class CharacterController : MonoBehaviour {
	public float maxSpeed = 40f;
	private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;

    private float headToFeetDist = 3f;

    public Vector3 goalPosition;

    private static int Z_DISPLACEMENT = -20;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        goalPosition = transform.position;
        //target = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y, Z_DISPLACEMENT);
        
        if (Input.GetButton("Fire1"))
            //Input.GetMouseButtonDown(0))
        {

            //Debug.Log("x: " + x);
            //Debug.Log("y: " + y);

            //Debug.Log("transform.position.x: " + transform.position.x);
            //Debug.Log("transform.position.y: " + transform.position.y);

            //target = new Vector3(x, y, Z_DISPLACEMENT);
            goalPosition = this.GetComponentInChildren<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z_DISPLACEMENT));
            goalPosition.y += headToFeetDist;
            //transform.position = new Vector3(x, y, Z_DISPLACEMENT);
            //Debug.Log("transform.position: " + transform.position);
            //Debug.Log(target);
        }
        if (transform.position != goalPosition)
            transform.position = Vector3.SmoothDamp(transform.position, goalPosition, ref velocity, .3f, maxSpeed);

        if (anim)
        {
            float moveX = goalPosition.x - transform.position.x;
            float moveY = goalPosition.y - transform.position.y;
            float move = (float)Math.Sqrt(Math.Pow(moveX, 2) + Math.Pow(moveY, 2));
            //get the current state
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

            anim.SetFloat("Speed", Mathf.Abs(move));

            //rigidbody2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
            if (moveX > 0 && !facingRight)
                flip();
            else if (moveX < 0 && facingRight)
                flip();
        }
	}
	
	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
