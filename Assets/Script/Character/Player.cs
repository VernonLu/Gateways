using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float maxSpeed = 10.0f;
    public float moveForce = 365f;
    public float jumpForce = 10.0f;

    private bool jump = false;
	private bool facingRight = false;
    private bool grounded = true;
	private Rigidbody2D player;
    private Transform groundCheck;

    private bool canGrab;
    private bool grabbing;
    private Transform grabCheck;

    private Transform prop;
    public AudioClip[] clips;

    private Collider2D other;
    private bool canShow = false;

    public Transform spawnPoint;
    private bool isDead = false;
    public AudioSource deathAudio;

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        grabCheck = transform.Find("grabCheck");
    }
    void Start () {
		player = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        GroundCheck();
        if (Input.GetButtonDown("Interactive"))
        {
            if (null != other && null != other.GetComponent<ChangeSize>() && canShow)
            {
                other.GetComponent<ChangeSize>().Show();
            }
        }
        Grab();
	}

	void FixedUpdate(){
        //MOVE
		float h = Input.GetAxis("Horizontal");
        if (h * player.velocity.x < maxSpeed)
        {
            player.AddForce(Vector2.right * h * moveForce);
        }
        if (Mathf.Abs(player.velocity.x) > maxSpeed)
        {
            //keep current speed while reaching max speed
            player.velocity = new Vector2(Mathf.Sign(player.velocity.x) * maxSpeed, player.velocity.y);
        }
        //Turning
        //Turn right while facing left on pressing right
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        //Turning left while facing right and pressing left
        else if (h < 0 && facingRight)
        {
            Flip();
        }
        //Jump
        if (jump)
        {
            //Debug.Log("Jump");
            //对角色施力跳跃
            player.AddForce(new Vector2(0f, jumpForce));
            //改变角色跳跃状态判断，防止角色在空中跳跃
            jump = false;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 11)
        {
            //Debug.Log("Enter");
            canShow = true;
            other = collision;
        }
        if (collision.gameObject.layer == 15)
        {
            deathAudio.clip = clips[1];
            deathAudio.Play();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canShow = false;
    }

    private void Flip(){
		facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}
    private void GroundCheck()
    {
        //检查是否接触地面
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Grab"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
    private void Grab()
    {
        if (Input.GetButtonDown("Interactive"))
        {
            if (!grabbing)
            {
                canGrab = Physics2D.Linecast(transform.position, grabCheck.position, 1 << LayerMask.NameToLayer("Grab"));
                Vector2 direction = grabCheck.position - transform.position;
                float distance = direction.magnitude;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, 1 << LayerMask.NameToLayer("Grab") | 0 << LayerMask.NameToLayer("Player"));

                if (canGrab)
                {
                    //Debug.Log(hit.transform.name);
                    prop = hit.transform;
                    prop.SetParent(this.transform,true);
                    //Debug.Log("Grab");
                    grabbing = true;
                }

            }
            else
            {
                prop.parent = null;
                prop = null;
                grabbing = false;
            }
        }
        //检查是否有可抓取物体
    }


    public void PlayerDead()
    {
        if (!isDead)
        {
            deathAudio.clip = clips[0];
            deathAudio.Play();
            transform.SetPositionAndRotation(spawnPoint.position, Quaternion.identity);
        }
    }
    
}
