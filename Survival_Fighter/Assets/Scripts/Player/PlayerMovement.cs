using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public bool isGrounded;
    Vector2 movement;
    Animator anim;
    Rigidbody2D rb;
    PlayerPickup playerPickup;

    void Start() {

        isGrounded = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerPickup = GetComponent<PlayerPickup>();
    }


	// Update is called once per frame
	void Update () {
        
        Movement();
	}

    void Movement() {

        if(playerPickup.canMelee)
        {
            anim.SetFloat("Moving", Mathf.Abs(Input.GetAxis("Horizontal")));
        }
       else
            anim.SetFloat("GunMoving", Mathf.Abs(Input.GetAxis("Horizontal")));
            

        if(Input.GetAxisRaw("Horizontal") > 0) // right
        {
            if(transform.position.x >= 8.65)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0) // left
        {
            if (transform.position.x <= -8.65)
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * speed * 70);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //crouch
        }
    }

    void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "Ground")
            isGrounded = true;
    }

}
