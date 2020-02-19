using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D dataFromCollision)
    {
    
        string name = dataFromCollision.gameObject.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            if (Input.GetAxis("Vertical") > 0)
            {
                animator.SetFloat("VerticalSpeed", 1);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                animator.SetFloat("VerticalSpeed", -1);
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (Input.GetAxis("Vertical") == 0)
                {
                    animator.SetFloat("HorizontalSpeed", 1);
                }
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                if (Input.GetAxis("Vertical") == 0)
                {
                    animator.SetFloat("HorizontalSpeed", -1);
                }
            }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        animator.SetFloat("VerticalSpeed", 0);
        animator.SetFloat("HorizontalSpeed", 0);
    }
}
