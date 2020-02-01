using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody rb;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            //rb.drag = 1;
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
