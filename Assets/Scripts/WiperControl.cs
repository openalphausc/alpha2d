using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float moveX = 0;
      float moveY = 0;
      if(Input.GetKey(KeyCode.RightArrow)) moveX = speed;
      else if(Input.GetKey(KeyCode.LeftArrow)) moveX = -speed;
      if(Input.GetKey(KeyCode.UpArrow)) moveY = speed;
      else if(Input.GetKey(KeyCode.DownArrow)) moveY = -speed;
      transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }
}
