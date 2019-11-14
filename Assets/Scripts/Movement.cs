using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D Rb;
    private Collider2D Cl;
    public float MovementSpeed = 5f;
    public float JumpHeight = 5f;
    public bool Grounded;
    public Transform GroundCheck;
    public float GroundRadius;
    public LayerMask WhatIsGround;
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Cl = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Fire();
    }

    private void FixedUpdate()
    {
        IsGround();
    }

    private void Run()
    {
        float xInput = Input.GetAxis("Horizontal");
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

    private void Fire()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(Projectile, transform.position, Quaternion.identity);
        }
                
    }

}
