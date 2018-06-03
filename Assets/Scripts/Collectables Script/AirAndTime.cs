using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAndTime : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (gameObject.name == "Air")
            {
                GameObject.Find("GamePlay Controller").GetComponent<AirTimer>().air += 15f;

            }
            else
            {
                GameObject.Find("GamePlay Controller").GetComponent<LevelTimer>().timer += 15f;
            }
            Destroy(gameObject);
        }
    }
}
