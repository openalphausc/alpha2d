using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public bool opCannon;
    public string cannonName;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        opCannon = false;
        cannonName = "";
    }

    void OnCollisionEnter2D(Collision2D dataFromCollision)
    {
    
        string name = dataFromCollision.gameObject.name;
        Debug.Log("name: " + name);
        if (name == "Cannon1" || name == "Cannon2" ||
            name == "Cannon3" || name == "Cannon4" ||
            name == "Cannon5")
        {
            Debug.Log("Inside If");
            opCannon = true;
            cannonName = name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (opCannon == true)
        {
            //Breaks cannon operation
            if (Input.GetKey("c"))
            {
                opCannon = false;
                cannonName = "";
            }
            //Lock player position to cannon
            
            if (cannonName == "Cannon5")
            {
                Vector3 newPos = new Vector3(-4.41f, .39f, 0);
                transform.position = newPos;
            }
            else if (cannonName == "Cannon4")
            {
                Debug.Log("Hello");
                Vector3 newPos = new Vector3(-.94f, -0.75f, 0);
                transform.position = newPos;
            }
            else if(cannonName == "Cannon3")
            {
                Vector3 newPos = new Vector3(-.9f, 1.1f, 0);
                transform.position = newPos;
            }
            else if(cannonName == "Cannon2")
            {
                Vector3 newPos = new Vector3(1.51f, -0.48f, 0);
                transform.position = newPos;
            }
            else if(cannonName == "Cannon1")
            {
                Vector3 newPos = new Vector3(1.7f, 1.17f, 0);
                transform.position = newPos;
            }
            
        }
        else
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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        animator.SetFloat("VerticalSpeed", 0);
        animator.SetFloat("HorizontalSpeed", 0);
    }
}
