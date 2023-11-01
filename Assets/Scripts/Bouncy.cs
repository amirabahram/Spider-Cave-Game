using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float force = 900f;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    IEnumerator AnimBouncy()
    {
        anim.Play("Bounce");

        yield return new WaitForSeconds(0.5f);
        anim.Play("Idle");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimBouncy());
        }
    }
}
