using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public static Door instance;// hàm tĩnh có thể sử dụng biến này và truy xuất

    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int collecttablesCount;

    void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this; // trỏ tới claas gần nhất là Door
        }
    }
    // ăn được các item thì nó sẽ giảm xuống 0 thì cửa sẽ mở
    public void DecrementCollectables()
    {
        collecttablesCount--;
        if (collecttablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameObject.Find("GamePlay Controller").GetComponent<GamePlayController>().PlayerDied();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
