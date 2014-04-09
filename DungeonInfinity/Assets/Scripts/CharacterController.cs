using UnityEngine;
using System;

public class CharacterController : MonoBehaviour {
    public GameObject Sword;
    public GameObject Chestplate;

	public float maxSpeed = 60f;
	private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;

    private float headToFeetDist = 3f;

    public Vector3 goalPosition = Vector3.zero;

    private static int Z_DISPLACEMENT = -20;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        goalPosition = transform.position;
        //target = Vector3.zero;
        Sword.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y, Z_DISPLACEMENT);
        
        
        if (Input.GetButton("Fire1"))
        {
            goalPosition = this.GetComponentInChildren<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z_DISPLACEMENT));
            goalPosition.y += headToFeetDist;
        }
        if (transform.position != goalPosition)
            transform.position = Vector3.SmoothDamp(transform.position, goalPosition, ref velocity, .1f, maxSpeed);

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

        if (facingRight)
        {
            Sword.transform.position = new Vector3(transform.position.x + 3, transform.position.y, Z_DISPLACEMENT);
        }
        else
        {
            Sword.transform.position = new Vector3(transform.position.x - 3, transform.position.y, Z_DISPLACEMENT);
        }

        Chestplate.transform.position = new Vector3(transform.position.x, transform.position.y - 1, Z_DISPLACEMENT);
	}
	
	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;

        Vector3 chest = Chestplate.transform.localScale;
        chest.x *= -1;

        Vector3 sord = Sword.transform.localScale;
        sord.x *= -1;

		transform.localScale = theScale;
        Chestplate.transform.localScale = chest;
        Sword.transform.localScale = sord;
	}
	
}
