using System.Collections;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed, sprintspeed, jumpforce, dashspeed;

    Rigidbody2D rb;
    TrailRenderer trail;
    public AudioSource walk;
    public AudioSource jump;
    public AudioSource dash;
    public AudioSource bgm;
    public AudioSource za;
    public AudioSource toki;

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


    float horizontal, vertical;
    bool jumpInput, sprinting, dashInput;

    bool timestop;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        bgm.Play();
    }

    // Update is called once per frame

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetKeyDown(jumpKey);
        sprinting = Input.GetKey(sprintKey);
        dashInput = Input.GetKeyDown(dashKey);

        //Debug.Log(isGrounded());
        //Debug.Log(rb.velocity);
        PlayerInput();

        if (isGrounded() && !isDashing)
            candash = true;

        PlayAudio();

    }

    void PlayAudio() 
    { 
        if (jumpInput && isGrounded() && !jump.isPlaying) { walk.Stop(); jump.Play(); }
        if (isDashing) jump.Stop();

        if (isDashing && !dash.isPlaying) { walk.Stop(); dash.Play(); }
        //if (!isDashing) dash.Stop();

        if (dashInput || jumpInput) walk.Stop();
        if (horizontal != 0 && isGrounded() && !walk.isPlaying)  walk.Play();
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(new Vector2(groundCheck.position.x, groundCheck.position.y), groundDistance, ground) == true;
    }

    public void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.F9) && timestop == false) StartCoroutine(zawarudo());

            if (sprinting && !isDashing) rb.velocity = new Vector2(horizontal * sprintspeed, rb.velocity.y);
        else if (!isDashing) rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        lookdir = new Vector2(horizontal, vertical);

        if (dashInput && candash)
        {
            //Debug.Log("yo");
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

    IEnumerator zawarudo()
    {
        timestop = true;

        if (!za.isPlaying) 
            za.Play();
        yield return new WaitForSeconds(1);
        time.timestop = true;
        yield return new WaitForSeconds(5);
        toki.Play();
        yield return new WaitForSeconds(2);
        time.timestop = false;

        timestop = false;
    }
}
