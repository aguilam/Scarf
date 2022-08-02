using UnityEngine;

public class Scarfs : MonoBehaviour
{
    Rigidbody2D rb;
    private bool top;
    public int lungeImpulse;
    private bool lockLunge = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    }
    void Update()
    {
        Gravity();
        Dash();
    }
    void Gravity()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            rb.gravityScale *= -1;
            if (top == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 100f);
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
            }
            top = !top;

        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            lockLunge = true;
            Invoke("LungeLock", 2f);
            rb.velocity = new Vector2(0, 0);
            if (rb.transform.localScale.x < 0) { rb.AddForce(Vector2.left * lungeImpulse); }
            else { rb.AddForce(Vector2.right * lungeImpulse); }

        }
    }
    void DashLock()
    {
        lockLunge = false;
    }
}
