using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Rb;
    private Collider2D Cl;
    public float MovementSpeed = 5f;
    public float JumpHeight = 5f;
    private float xDir = 1;
    private float xInput;   
    public bool Grounded;
    public Transform GroundCheck;
    public float GroundRadius;
    public LayerMask WhatIsGround;
    public Animator animator;
    public Transform character;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Cl = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        character = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    private void FixedUpdate()
    {
        IsGround();
        Direction();
    }

    private void Run()
    {
        xInput = Input.GetAxis("Horizontal");
        Vector2 PlayerVelocity = new Vector2(xInput * MovementSpeed, Rb.velocity.y);
        Rb.velocity = PlayerVelocity;
    }

    private void Jump()
    {
        if (Grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 JumpVelocity = new Vector2(0, JumpHeight);
                Rb.velocity += JumpVelocity;
            }
        }       
    }

    private void IsGround()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, WhatIsGround);
    }


    private void Direction()
    {
        if (xInput == 1)
        {
            xDir = 1;
            animator.SetTrigger("IsWalking");
            character.localScale = new Vector3(-1, 1, 1);
        }
        else if (xInput == -1)
        {
            xDir = -1;
            animator.SetTrigger("IsWalking");
            character.localScale = new Vector3(1, 1, 1);
        } else if (xInput == 0) 
        {
            animator.ResetTrigger("IsWalking");
        }
    }
}
