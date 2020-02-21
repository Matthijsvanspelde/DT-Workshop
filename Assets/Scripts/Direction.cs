using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private float xDir = 1;
    private float xInput;
    public Animator animator;
    public Transform character;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
    }

    private void SetDirection()
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
        }
        else if (xInput == 0)
        {
            animator.ResetTrigger("IsWalking");
        }
    }
}
