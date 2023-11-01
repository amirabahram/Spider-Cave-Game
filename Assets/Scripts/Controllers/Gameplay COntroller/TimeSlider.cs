using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    public float time = 60f;
    private float timeBurn = 1f;
    private void Awake()
    {
        GetRefrences();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (!player) return;
        if (time > 0)
        {
            time -= timeBurn * Time.deltaTime;
            slider.value = time;
        }
        else
        {
            Destroy(player);
            GetComponent<GameplayController>().PlayerDied();
        }
    }
    void GetRefrences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = slider.maxValue;

    }
}
