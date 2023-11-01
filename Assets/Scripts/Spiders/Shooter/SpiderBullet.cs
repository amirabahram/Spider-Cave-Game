using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();

        }
        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
