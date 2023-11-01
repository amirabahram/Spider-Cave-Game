using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        Instantiate(bullet,transform.position,Quaternion.identity);
        StartCoroutine(SpawnBullets());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            
        }
    }
}
