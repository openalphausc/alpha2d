using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudCollide : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
      Debug.Log("Colliding");
        if (other.name == "Wiper" && Input.GetKey("space"))
        {
          Debug.Log("Colliding with wiper and space.");
            Destroy(gameObject);
        }
    }
}
