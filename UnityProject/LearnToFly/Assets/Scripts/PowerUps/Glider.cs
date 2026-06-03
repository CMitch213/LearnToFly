using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    public float pitchSpeed = 100f;
    public float liftStrength = 0.5f;
    public float drag = 0.01f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        float speed = velocity.magnitude;

        Vector2 forward = transform.right;

        // Lift acts perpendicular to forward direction
        Vector2 liftDir = new Vector2(-forward.y, forward.x);

        float liftAmount = speed * speed * liftStrength;

        rb.AddForce(liftDir * liftAmount);

        // Air resistance
        rb.AddForce(-velocity * speed * drag);
    }
}
