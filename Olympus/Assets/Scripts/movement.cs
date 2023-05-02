using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed, sprintspeed, jumpforce, dashspeed;

    Rigidbody2D rb;

    [Header("GROUND CHECK")]
    public Transform groundCheck;
    public LayerMask ground;
    public float groundDistance = 0.5f;

    [Header("KEYCODES")]
    public KeyCode jumpKey, sprintKey, dashKey;

    Vector2 lookdir;

    public bool isDashing, hasDashed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        Debug.Log(isGrounded());
        //Debug.Log(rb.velocity);
        PlayerInput();

        if (isGrounded() == true)
            hasDashed = false;

    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(new Vector2(groundCheck.position.x, groundCheck.position.y), groundDistance, ground);
    }

    public void PlayerInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical"); 
        bool jumpInput   = Input.GetKeyDown(jumpKey);
        bool sprinting   = Input.GetKey(sprintKey);

        if (sprinting && !isDashing) rb.velocity = new Vector2(horizontal * sprintspeed, rb.velocity.y);
        else if (!isDashing) rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        lookdir = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown(dashKey) && !hasDashed) Dash(lookdir.x, lookdir.y);

        if (jumpInput && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

        
    }

    private void Dash(float x, float y)
    {
        hasDashed = true;

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        rb.velocity += dir * dashspeed;
        StartCoroutine(DashWait());
    }
    IEnumerator DashWait()
    {
        StartCoroutine(GroundDash());

        rb.gravityScale = 0;
        isDashing = true;

        yield return new WaitForSeconds(.3f);

        rb.gravityScale = 3;
        isDashing = false;
    }
    IEnumerator GroundDash()
    {
        yield return new WaitForSeconds(.15f);
        if (isGrounded())
            hasDashed = false;
    }
}
