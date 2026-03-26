using UnityEngine;
using UnityEngine.Events;

public class PlayerCollide : MonoBehaviour
{
 [SerializeField]
 private string obstacleTag = "Obstacle";
 [SerializeField]
 private string coinTag = "Coin";
 [SerializeField]
 private string jumpPowerUpTag = "JumpPowerUp";
 [SerializeField]
 private UnityEvent<Transform> onMagnetCollected;
 [SerializeField]
 private UnityEvent<Transform> onObstacleCollision;
 [SerializeField]
 private UnityEvent<Transform> onJumpPowerUpCollected;
 [SerializeField]
 private UnityEvent<Transform> onCoinCollected;
 private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            onObstacleCollision?.Invoke(transform);
        }
        else if (other.CompareTag(coinTag))
        {
            collectCoin(other.gameObject);
        }
        else if (other.CompareTag(jumpPowerUpTag))
        {
            onJumpPowerUpCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Magnet"))
        {
            onMagnetCollected?.Invoke(transform);
            other.gameObject.SetActive(false);
        }
    }
    public void collectCoin(GameObject coin)
    {
        coin.SetActive(false);
        onCoinCollected?.Invoke(transform);
    }
}
