using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlling : MonoBehaviour
{
    public float Speed;
    public float Jump;
    //public float ShortJump;
    //public float Dash;
    //public ParticleSystem dashParticle;
    public GameObject JumpUI;
    public GameObject DashUI;
    public GameObject TutorialUI;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    //public Vector2 movement;

    public bool IsJumping;
    public bool JumpUnlock = false;
    public bool isJ = false;
    public bool isU = false;
    public bool isM = false;
    public bool isP = false;

    public bool DashUnlock = false;
    public bool isD = false;
    public bool isA = false;
    public bool isS = false;
    public bool isH = false;

    private float movement;
    private Rigidbody2D body;
    private new SpriteRenderer renderer;
    private Animator animator;

    public float currentScore;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Move horizontal
        //body.AddForce(new Vector2(Input.GetAxis("Horizontal") * Speed, 0));
        movement = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(movement * Speed, body.velocity.y);

        // Move vertical
        if (JumpUnlock && Input.GetButtonDown("Jump") && !IsJumping)
        {
            body.AddForce(new Vector2(body.velocity.x, Jump));
            IsJumping = true;
        }

        //if (DashUnlock && Input.GetKeyDown(KeyCode.LeftShift) && !IsJumping)
        //{
           //body.AddForce(new Vector2(body.velocity.x + Dash, ShortJump));
           // IsJumping = true;
        //}

        /*if(Input.GetKeyDown("escape")){
            Application.Quit();
        }

        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }*/

        // Face the right direction
        if (movement < 0)
            renderer.flipX = true;
        else if (movement > 0)
            renderer.flipX = false;

        if (direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && DashUnlock)
            {
                if(movement < 0)
                {
                    //Instantiate(dashParticle, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    //dashEffect();
                    direction = 1;
                }
                else if (movement > 0)
                {
                    //Instantiate(dashParticle, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                   // dashEffect();
                    direction = 2;
                }
                FindObjectOfType<AudioManager>().Play("DashEffect");
            }
        }
        else{
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                body.velocity = Vector2.zero;
            }
            else{
                //Instantiate(dashParticle, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                //dashEffect();
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    body.velocity = Vector2.left * dashSpeed;
                }
                else if(direction == 2)
                {
                    body.velocity = Vector2.right * dashSpeed;
                }
            }
        }
        

        // Update animator parameters
        animator.SetBool("OnGround", !IsJumping);
        animator.SetBool("MovingHorizontal", body.velocity.x != 0);
        animator.SetFloat("VerticalVelocity", body.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("J"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isJ = true;
        }

        else if(other.gameObject.CompareTag("U"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isU = true;
        }

        else if(other.gameObject.CompareTag("M"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isM = true;
        }

        else if(other.gameObject.CompareTag("P"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isP = true;
        }

        else if(other.gameObject.CompareTag("D"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isD = true;
        }

        else if(other.gameObject.CompareTag("A"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isA = true;
        }

        else if(other.gameObject.CompareTag("S"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isS = true;
        }

        else if(other.gameObject.CompareTag("H"))
        {
            FindObjectOfType<AudioManager>().Play("KeyWord");
            Destroy(other.gameObject);
            isH = true;
        }

        else if(other.gameObject.CompareTag("Score"))
        {
            Destroy(other.gameObject);
            currentScore += 25;
            FindObjectOfType<AudioManager>().Play("Crystal");
        }

        if(isJ && isU && isM && isP)
        {
            if(JumpUnlock == false){
            FindObjectOfType<AudioManager>().Play("Unlock");
            JumpUnlock = true;
            JumpUI.SetActive(true);
            }
        }

        if(other.gameObject.CompareTag("TutorialUI"))
        {
            FindObjectOfType<AudioManager>().Play("Theme");
            Destroy(other.gameObject);
            TutorialUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Unlock");
        }

        if(isD && isA && isS && isH)
        {
            if(DashUnlock == false)
            {
            DashUnlock = true;
            DashUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Unlock");
            }
        }

        if(other.gameObject.CompareTag("Goal"))
        {
            movement = 0;
            FindObjectOfType<GameManage>().CompleteLevel();
        }

        if(other.gameObject.CompareTag("Endzone"))
        {
            movement = 0;
            FindObjectOfType<GameManage>().FailLevel();
        }
        
    }

    //void dashEffect(){
      //  dashParticle.Play();
    //}
}