using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {
    [SerializeField]
    private Transform starPos, endPos; // vị trí bắt đầu và kết thúc
    private bool collision; //bắt va chạm

    public float speed = 1f; //tốc độ di chuyển
    private Rigidbody2D myBody;

    // Use this for initialization
    //làm rõ biến
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start () {
		
	}
	
    void ChangeDirection() //tính sự va chạm collision
    {
        //lấy tên layer nền đất để va chạm
        collision = Physics2D.Linecast(starPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground")); //gắn cho sự va chạm cho biến collision dùng physic2d
        Debug.DrawLine(starPos.position, endPos.position, Color.green);
        if (!collision)// không có sự va chạm giữa con nhện và nền đất
        {
            Vector3 temp = transform.localScale; //chuyển vị trí con nhện
            if (temp.x == 1f)//đang di chuyển bên phải
            {
                temp.x = -1f; // đổi về bên trái
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp; // gắn tọa độ ngược lại
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }
    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            GameObject.Find("GamePlay Controller").GetComponent<GamePlayController>().PlayerDied();
            Destroy(target.gameObject);
        }
    }
    void Update () {
		
	}
}
