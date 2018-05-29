using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Door.instance != null)
        {
            Door.instance.collecttablesCount++;
        }
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            if (Door.instance != null) // luôn luôn phải có hàm Door
            {
                Door.instance.DecrementCollectables();//nhân vật ăn 1 viên sẽ giảm 1 đơn vị
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
