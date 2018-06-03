using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float moveForce = 20f; //tốc độ di chuyển
    public float jumpForce = 700f; //nhảy với tốc độ bao nhiêu
    public float maxVelocity = 4f; //vận tốc

    private bool grounded; //dùng để so sánh với nền đất để có thể di chuyển và nhảy

    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveLeft, moveRight;
    // Use this for initialization

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(() => Jump());
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }
    public void StopMoving()
    {
        this.moveLeft = false;
        this.moveRight = false;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        PlayerWalkerJoyStick();
        //PlayerWalkKeyBoard();
    }

    //di chuyển bằng joystick
    void PlayerWalkerJoyStick()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (moveRight)
        {
            if (vel < maxVelocity)
            {//nhân vật di chuyển về bên phải
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.lossyScale; //di chuyển nhân vậy thì player sẽ quay  về vị trí đó
            scale.x = 1f;
            transform.localScale= scale;

            anim.SetBool("Walk", true);
        }
        else if (moveLeft)
        {
            if (vel < maxVelocity)
            {//nhân vật di chuyển về bên trái
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            Vector3 scale = transform.lossyScale; //di chuyển nhân vậy thì player sẽ quay  về vị trí đó
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        else
        {
            anim.SetBool("Walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0));
    }

    //di chuyển bằng bàn phím
    void PlayerWalkKeyBoard()
    {
        float forceX = 0f; //di chuyển theo chiều ngang;
        float forceY = 0f; //nhảy lên;

        float vel = Mathf.Abs(myBody.velocity.x); //vận tốc luôn là dương
        float h = Input.GetAxisRaw("Horizontal"); //A <-- or D --> (-1 0 1)

        if (h>0)
        {
            if (vel < maxVelocity)
            {//nhân vật di chuyển về bên phải
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }

            }
            Vector3 scale = transform.localScale;//Di chuyển nhân vật thì player sẽ di chuyển về vị trí đó
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);

        }
        else if (h<0)
        {
            if (vel <maxVelocity)
            {//nhân vậy di chuyển về bên trái
                if (grounded)
                {
                    forceX = -moveForce;

                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }

            }
            Vector3 scale = transform.localScale;// Di chuyển nhân vật thì player sẽ quay về vị trị đó
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;//bay lên thì mới nhảy
                forceY = jumpForce;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    public void BouncePlayerWithBouncy(float force)
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, force));//nhảy theo chiề y nên cho x = 0; y sẽ = force
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, jumpForce));//nhảy theo chiề y nên cho x = 0; y sẽ = force
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
