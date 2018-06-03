using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour {
    [SerializeField]
    private GameObject bullet;
    // Use this for initialization
    void Start () {
        StartCoroutine(Attack   ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Attack() //Nhện sẽ bắn đạn
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        Instantiate(bullet, transform.position, Quaternion.identity);//viên đạn sẽ nằm ngay vị trí nhện
        StartCoroutine(Attack   ());
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameObject.Find("GamePlay Controller").GetComponent<GamePlayController>().PlayerDied();
            Destroy(target.gameObject); // hủy nhân vật
        }
    }
}
