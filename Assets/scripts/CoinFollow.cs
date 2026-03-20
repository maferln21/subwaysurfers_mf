using UnityEngine;

public class CoinFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float followSpeed = 5f;
    [SerializeField]
    private float minimumDistance = 0.05f;
    private bool canFollow = true;
    private Vector3 originalPosition = Vector3.zero;
    private void Awake()
    {
        originalPosition = transform.localPosition;
    } 
    private void OnEneable()
    {
        canFollow = true;
        player = null;
        if (originalPosition != Vector3.zero) transform .localPosition = originalPosition;
     }
    public void StartFollwing(Transform playerTransform)
    {
        if(!canFollow) return;
        canFollow = false ;
        player = playerTransform;
    }
    public void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < minimumDistance)
            {
            player = null;
        
            }
        }
    }
}
