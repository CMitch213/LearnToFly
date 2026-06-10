using UnityEngine;

public class Glider : MonoBehaviour
{
    public Rigidbody2D rb;

    void FixedUpdate()
    {
        Vector2 vel = rb.velocity;

        float pitch = transform.right.y; // -1 down, +1 up

        // Only glide when moving fast enough
        if (vel.magnitude > 5f)
        {
            // How much we're trying to glide
            float glideAmount = Mathf.Max(0f, pitch);

            // Reduce falling
            vel.y += glideAmount * 15f * Time.fixedDeltaTime;

            // Lose horizontal speed while climbing
            vel.x *= 1f - glideAmount * 0.01f;
        }

        rb.velocity = vel;
    }
}