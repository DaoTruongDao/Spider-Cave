using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour {
    public float forceY = 300; //Lực nhảy của nhện
    private Rigidbody2D myBody;
    private Animator anim;
    // Use this for initialization

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start () {
        StartCoroutine(Attack());
	}

    IEnumerator Attack() //nhện tấn công
    {
        yield return new WaitForSeconds(Random.Range(2, 7)); //2 , 7s con nhện tấn công
        forceY = Random.Range(200f, 500f); // lực nhảy ngẫu nhiên

        myBody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(.7f);
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
        }
        if (target.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
