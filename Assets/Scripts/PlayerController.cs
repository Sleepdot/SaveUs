using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Jump;
    //public Vector2 movement;

    public Boolean IsJumping;

    private float movement;
    private Rigidbody2D body;
    private new SpriteRenderer renderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move horizontal
        //body.AddForce(new Vector2(Input.GetAxis("Horizontal") * Speed, 0));
        movement = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(movement * Speed, body.velocity.y);

        // Move vertical
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            body.AddForce(new Vector2(body.velocity.x, Jump));
            IsJumping = true;
        }
        

        // Face the right direction
        if (movement < 0)
            renderer.flipX = true;
        else if (movement > 0)
            renderer.flipX = false;

        // Update animator parameters
        animator.SetBool("OnGround", !IsJumping);
        animator.SetBool("MovingHorizontal", body.velocity.x != 0);
        animator.SetFloat("VerticalVelocity", body.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Foods"))
        {
            FindObjectOfType<AudioManager>().Play("Eat");
            Destroy(other.gameObject);
            FindObjectOfType<CountTime>().addTime();
        }

        if(other.gameObject.CompareTag("Diets"))
        {
            FindObjectOfType<AudioManager>().Play("Ate");
            Destroy(other.gameObject);
            FindObjectOfType<CountTime>().subtractTime();
        }

        if(other.gameObject.CompareTag("Goal"))
        {
            movement = 0;
            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }

}