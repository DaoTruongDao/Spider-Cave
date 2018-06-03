using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

    private Slider slider;
    private GameObject player;
    public float timer = 10f;
    private float timeBurn = 1f;

    void Awake()
    {
        GetPreferences();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!player)
            return;
        if (timer > 0)
        {
            timer -= timeBurn * Time.deltaTime;
            slider.value = timer;
        }
        else
        {
            Destroy(player);
        }
	}
    void GetPreferences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
