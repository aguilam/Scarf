using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    public float jumpForce = 210f;
    private int jumpCount = 0;
    public int maxJumpValue = 2;
    public bool onGround;
    public Transform groundChecker;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    private float groundCheckerRadius;
    public int lungeImpulse;
    private bool lockLunge = false;
    public bool faceRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheckerRadius = groundChecker.GetComponent<CircleCollider2D>().radius;
    }
    void Update()
    {
        Walk();
        Jump();
        CheckingGround();
        Lunge();
        Reflect();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");

        rb.AddForce(moveVector * speed);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Invoke("IgnoreLayerOff", 0.7f);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if (++jumpCount < maxJumpValue)
            {
                rb.velocity = new Vector2(0, 7.25f);
            }
        }
        if (onGround) { jumpCount = 0; }
    }
    void Lunge()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            lockLunge = true;
            Invoke("LungeLock", 2f);
            rb.velocity = new Vector2(0, 0);
            if (!faceRight) { rb.AddForce(Vector2.left * lungeImpulse); }
            else { rb.AddForce(Vector2.right * lungeImpulse); }
            
        }
    }
    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, Ground);

    }
    void LungeLock()
    {
        lockLunge = false;
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

}
