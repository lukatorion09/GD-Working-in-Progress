using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      
    public float smoothSpeed = 5f; 

    private Vector3 offset;       

    void Start()
    {
        offset = transform.position - target.position;
        offset.y = transform.position.y;
        offset.z = transform.position.z;
    }

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, offset.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}

