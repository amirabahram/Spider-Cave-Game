using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if (gameObject.name == "Air")  GameObject.Find("Gameplay Controller").GetComponent<AirTimer>().air += 10f;
            if (gameObject.name == "Time") GameObject.Find("Gameplay Controller").GetComponent<TimeSlider>().time += 10f;
            
        }
    }
}
