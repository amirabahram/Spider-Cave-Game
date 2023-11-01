using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float air = 60f;
    private float airBurn = 1f;
    private void Awake()
    {
        GetRefrences();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;

        if(air > 0)
        {
            air = air - airBurn * Time.deltaTime;
            slider.value = air;
        }
        else
        {
            GetComponent<GameplayController>().PlayerDied();

            Destroy(player);
        }
    }
    void GetRefrences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Air Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;

    }
}
