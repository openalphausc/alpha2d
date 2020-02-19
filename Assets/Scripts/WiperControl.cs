using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperControl : MonoBehaviour
{
    public float wiperSpeed;
    private Rigidbody2D rb;
    private PlayerController playerScript;
    private float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        wiperSpeed = 0.1f;
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Body").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      float moveX = 0;
      float moveY = 0;
      playerSpeed = playerScript.speed;
      // If player is moving, move at the same speed as the player
      if(Input.GetKey("d")) moveX += playerSpeed; // make "speed" the player object's speed
      else if(Input.GetKey("a")) moveX -= playerSpeed;
      // If input is given, move the wiper
      if(Input.GetKey(KeyCode.RightArrow)) moveX += wiperSpeed;
      else if(Input.GetKey(KeyCode.LeftArrow)) moveX -= wiperSpeed;
      if(Input.GetKey(KeyCode.UpArrow)) moveY += wiperSpeed;
      else if(Input.GetKey(KeyCode.DownArrow)) moveY -= wiperSpeed;
      transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
    }
}
