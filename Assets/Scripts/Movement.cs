using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Speeds { Slow = 0, Normal = 1, Fast = 2, Faster = 3, Fastest = 4 };
public class Movement : MonoBehaviour
{
    public Speeds CurrentSpeed;
    float[] SpeedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Vector3.right * SpeedValues[(int)CurrentSpeed] * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (OnGround())
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
            }
        }
    }

    bool OnGround()
    {
        var collider =  Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
        
        return collider != null;
    }

    //bool OnGroundTwo()
    //{
    //    return Physics2D.Raycast() 
    //}
}