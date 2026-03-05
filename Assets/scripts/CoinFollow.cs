using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float followSpeed = 5f;
    [SerializeField]
    private float minimumDistance = 0.05f;
    private bool isFollowing = false;
    private Vector3 originalPosition;
    public void StartFollwing(Transform playerTransform)
    {
        originalPosition = transform.localPosition;
        player = playerTransform;
        isFollowing = true;
    }
    public void Update()
    {
        if (isFollowing && player != null)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < minimumDistance)
            {
            player = null;
            isFollowing = false;
            transform.localPosition = originalPosition;
            }
        }
    }
}
