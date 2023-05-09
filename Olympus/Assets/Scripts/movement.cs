using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed, sprintspeed, jumpforce, dashspeed;

    Rigidbody2D rb;
    TrailRenderer trail;

    [Header("GROUND CHECK")]
    public Transform groundCheck;
    public LayerMask ground;
    public float groundDistance = 0.5f;

    [Header("KEYCODES")]
    public KeyCode jumpKey, sprintKey, dashKey;

    Vector2 lookdir, dashdir;

    [Header("Dashing")]
    private float dashvel = 14f, dashtime = 0.5f;
    public bool isDashing, candash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame

    private void Update()
    {
        Debug.Log(isGrounded());
        //Debug.Log(rb.velocity);
        PlayerInput();

        if (isGrounded() && !isDashing)
            candash = true;

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
        bool dashInput   = Input.GetKeyDown(dashKey);

        if (sprinting && !isDashing) rb.velocity = new Vector2(horizontal * sprintspeed, rb.velocity.y);
        else if (!isDashing) rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        lookdir = new Vector2(horizontal, vertical);

        if (dashInput && candash)
        {
            Debug.Log("yo");
            isDashing = true;
            candash = false;
            trail.emitting = true;
            dashdir = lookdir;
            if (dashdir == Vector2.zero) 
            {
                dashdir = new Vector2(transform.localScale.x, 0); 
            }
            StartCoroutine(StopDash());
        }

        if (isDashing) { rb.velocity = dashdir.normalized * dashspeed; return; }

        if (jumpInput && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
              
    }

   
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashtime);
        isDashing = false;
        trail.emitting = false;
    }
}
