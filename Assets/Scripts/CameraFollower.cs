using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollower : MonoBehaviour
{
    private Transform player;
    private float maxX = 170f, minX = -10f;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y+3;
            if(temp.x > maxX) temp.x = maxX;
            if(temp.x < minX) temp.x = minX;
            transform.position = temp;
        }
        
        
    }

    


}
