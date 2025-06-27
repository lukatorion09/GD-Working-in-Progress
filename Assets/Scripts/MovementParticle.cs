using UnityEngine;

public class MovementParticles : MonoBehaviour
{
    public Transform player;                  // Reference to the player
    public LayerMask groundLayer;             // Layer for ground
    public Transform groundCheckPoint;        // Empty object under the player
    public float groundCheckRadius = 0.15f;   // Radius for ground check

    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (IsGrounded())
        {
            if (!ps.isPlaying)
                ps.Play();
        }
        else
        {
            if (ps.isPlaying)
                ps.Stop();
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
}
