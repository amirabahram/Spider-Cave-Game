using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private float jumpForce = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds( Random.Range(2, 7));
        jumpForce = Random.Range(250, 550);
        anim.SetBool("Attack", true);
        myBody.AddForce(new Vector2(0, jumpForce));
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Jump());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Destroy(collision.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            
        }

        if (collision.tag == "Ground")  anim.SetBool("Attack", false);
        
    }

}
