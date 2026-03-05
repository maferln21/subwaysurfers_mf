using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothSpeed = 0.125f;
    private Vector3 offset;
    private void Start()
    {
        Vector3 initialPosition = transform.position;
        offset = initialPosition - target.position;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothePosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothePosition;
    }
}
