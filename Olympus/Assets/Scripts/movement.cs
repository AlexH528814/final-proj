using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed, sprintspeed, jumpforce, dashforce, dashtime, dashcool, dashupforce;

    Rigidbody2D rb;

    [Header("GROUND CHECK")]
    public Transform groundCheck;
    public LayerMask ground;
    public float groundDistance = 0.5f;

    [Header("KEYCODES")]
    public KeyCode jumpKey, sprintKey, dashKey;

    Vector2 lookdir, dashdir;

    public bool canDash, isDashing;

    // Start is called before the first frame update
    void Start()
    {
        canDash = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        //Debug.Log(rb.velocity);
        PlayerInput();
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
        dashdir = new Vector2(horizontal * dashforce, vertical * dashupforce);

        if (Input.GetKeyDown(dashKey) && canDash) StartCoroutine(Dash());

        if (jumpInput && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
       
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float gravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = dashdir;
        yield return new WaitForSeconds(dashtime);
        rb.gravityScale = gravity;
        isDashing = false;
        yield return new WaitForSeconds(dashcool);
        canDash = true;
    }
}
