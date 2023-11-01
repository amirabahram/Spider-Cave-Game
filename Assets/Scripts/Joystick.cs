using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Player player;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name.Equals("Left"))
        {
            player.SetMoveLeft(true);
        }else if(gameObject.name.Equals("Right"))
        {
            player.SetMoveLeft(false);
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
         player.StopWalking();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
