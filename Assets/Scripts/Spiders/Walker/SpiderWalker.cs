using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float speed = 1.0f;
    [SerializeField]
    private Transform startPos, endPos;
    private bool collision;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPos.position,endPos.position,Color.green);
        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if(temp.x == 1f)
            {
                temp.x = -1;
            }
            else
            {
                temp.x = 1;
            }
            transform.localScale = temp;
        }
    }
    private void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }
    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();

        }
    }
}
