using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveForce = 20f, jumpForce = 700f, maxVelocity = 5f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool moveLeft, moveRight;

    private bool grounded;
    private void Awake()
    {
        InitializeVariables();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyboard();
        PlayerWalkJoystick();
        GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(() => Jump());
    }

    void InitializeVariables()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft; 
    }
    public void StopWalking()
    {
        this.moveRight = false;
        this.moveLeft = false;
    }
    private void Jump()
    {
        if (grounded)
        {
            grounded = false;
            float forceY = jumpForce;
            myBody.AddForce(new Vector2(0, forceY));
        }
    }
    void PlayerWalkJoystick()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (moveRight)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }

            }
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
            anim.SetBool("Walk", true);

        }
        else if (moveLeft)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0));
    }
    void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float forceY = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
                
            }
            Vector3 scale = transform.localScale;
            scale.x =  1;
            transform.localScale = scale;
            anim.SetBool("Walk", true);

        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.localScale;
            scale.x =  -1;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }else if( h == 0)
        {
            anim.SetBool("Walk", false);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded= true;
        }
    }

    public void BouncePlayerWithBouncy(float force)
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new  Vector2(0, force));
        }
    }
}
