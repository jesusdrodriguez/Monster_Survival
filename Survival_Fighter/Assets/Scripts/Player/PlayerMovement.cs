using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public bool isGrounded;
    Vector2 movement;
    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        isGrounded = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


	// Update is called once per frame
	void Update () {
        
        Movement();
	}

    void Movement()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxisRaw("Horizontal") > 0) // right
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0) // left
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * speed * 60);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //crouch
        }
    }
    void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.tag == "Ground")
            isGrounded = true;
    }

}
