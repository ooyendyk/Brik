using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float breakingSpeed = 60;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.magnitude < 12000)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //Vector3 v = transform.right * speed;/*Mathf.FloorToInt(sidewaysForce * Time.deltaTime)*/;
            //rb.velocity += v;
        }
        else if (Input.GetKey("a"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime * -1, 0, 0, ForceMode.VelocityChange);
            //Vector3 v = -transform.right * speed;/*Mathf.FloorToInt(sidewaysForce * Time.deltaTime)*/;
            //rb.velocity += v;
        }
        else
        {
            Vector3 vel = rb.velocity;
            if (rb.velocity.x > 1)
            {
                vel.x = breakingSpeed;
            }
            else if (rb.velocity.x < 1)
            {
                vel.x = -breakingSpeed;
            }
            rb.velocity -= vel * Time.deltaTime;
        }

        if(rb.position.y <-1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
