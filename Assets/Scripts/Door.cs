using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;
    private Animator anim;
    private BoxCollider2D box;
    [HideInInspector]
    public int collectablesCount;

    private void Awake()
    {
        MakeInstance ();
        anim = GetComponent<Animator> ();
        box = GetComponent<BoxCollider2D> ();
    }
    void MakeInstance()
    {
        if(instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecrementCollectables()
    {
        collectablesCount--;
        if(collectablesCount == 0 ) StartCoroutine(OpenDoor ());
    }
    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(0.7f);
        box.isTrigger = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
        }
    }
}
