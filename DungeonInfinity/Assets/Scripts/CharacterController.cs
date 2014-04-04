using UnityEngine;
using System;

public class CharacterController : MonoBehaviour {


	public float maxSpeed = 10;
	private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;
    public Vector3 target;
	Animator anim;
	
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(transform.position.x, transform.position.y, -20);

        if (Input.GetButton("Fire1")) {
            target = new Vector3(Input.mousePosition.x - Screen.width / 2,Input.mousePosition.y - Screen.height / 2,0);
            target.z = -20;

            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, .5f,20f);
        }



		float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float move = (float) Math.Sqrt(Math.Pow(moveX, 2) + Math.Pow(moveY,2));

		anim.SetFloat("Speed", Mathf.Abs(move));

        rigidbody2D.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
		if(moveX > 0 && !facingRight) 
			flip();
		else if(moveX < 0 && facingRight)
			flip();
		
		
	}
	
	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
