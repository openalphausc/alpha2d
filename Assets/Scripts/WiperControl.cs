using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiperControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float wiperSpeed;
    public float maxDistanceFromBody;

    private PlayerController playerScript;
    private Transform playerTransform;
    private float playerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        wiperSpeed = 0.1f;
        maxDistanceFromBody = 4.3f;

        playerScript = GameObject.Find("Body").GetComponent<PlayerController>();
        playerTransform = GameObject.Find("Body").transform;
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

      Vector2 newPos = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
      // check if newPos is legal (close enough to the body)
      float distance = Mathf.Abs(Vector2.Distance(newPos, playerTransform.position));
      if(distance < maxDistanceFromBody) transform.position = newPos;
    }
}
