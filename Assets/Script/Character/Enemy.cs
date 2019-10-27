using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public enum IdleMode { Animation, Move }
    public IdleMode idleMode = IdleMode.Move;
    public float hoverSpeed = 2.0f;
    public float chaseSpeed = 5.0f;
    public Animation idleAnima;

    public Vector2 scanRange;
    public float scanDistance;
    public float scanInterval = 1f;
    public Vector2 hoverRange;

    private Rigidbody2D rb;
    private Transform scanner;
    private float currnetAngle = 0f;
    private bool facingRight = true;

    private Vector3 targetPosition;
    private bool isAlert = false;
    private bool isActive = true;
    private Transform obstacleCheck;
    
	void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
        scanner = transform.Find("scanner");
        obstacleCheck = transform.Find("obstacleCheck");
        targetPosition = transform.position;
    }
	void Update () {
        if (CheckObstacle())
        {
            Flip();
        }
    }
    void FixedUpdate()
    {
        if (isAlert)
        {
            MoveTo(targetPosition);
        }
        else
        {
            Hover();
        }
        Scan();
    }
    private void Hover()
    {
        if (transform.position.x < hoverRange.x && !facingRight)
        {
            Flip();
        }
        else if (transform.position.x > hoverRange.y && facingRight)
        {
            Flip();
        }
        switch (idleMode)
        {
            case IdleMode.Animation:
                { if (!idleAnima.isPlaying) { idleAnima.Play(); } } break;
            case IdleMode.Move:
                { rb.velocity = Mathf.Sign(transform.localScale.x) * hoverSpeed * Vector2.right; } break;
        }
    }
    private void MoveTo(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        if (Mathf.Sign(direction.x) > 0 && !facingRight)
        {
            Flip();
        }
        else if (Mathf.Sign(direction.x) < 0 && facingRight)
        {
            Flip();
        }
        rb.velocity = Mathf.Sign(direction.x) * chaseSpeed * Vector2.right;
    }
    public void Alert(Vector3 position)
    {
        targetPosition = position;
        isAlert = true;
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Scan()
    {
        for(int i = 0; i < scanInterval; i++)
        {
            float deltaAngle = (scanRange.y - scanRange.x) / scanInterval / 90;
            currnetAngle = (deltaAngle * (i+1) * Random.Range(0.5f, 1.5f) + scanRange.x/90f) ;
            //Debug.Log(currnetAngle);
            Vector3 direction = new Vector3(Mathf.Cos(currnetAngle) * Mathf.Sign(transform.localScale.x), Mathf.Sin(currnetAngle), 0f);
            Debug.DrawLine(scanner.position, scanner.position + direction * scanDistance, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(scanner.position, direction, scanDistance, 1 << LayerMask.NameToLayer("Player"));
            if (null != hit.collider)
            {
                if (hit.collider.tag == "Player")
                {
                    //Kill player
                    hit.collider.GetComponent<Player>().PlayerDead();
                }
            }
        }
    }

    private bool CheckObstacle()
    {
        return Physics2D.Linecast(transform.position, obstacleCheck.position, 1 << LayerMask.NameToLayer("Grab"));
    }

}
