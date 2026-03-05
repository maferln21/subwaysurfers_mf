using UnityEngine;

public class MagnetCollider : MonoBehaviour
{
    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            CoinFollow coinFollow = other.GetComponent<CoinFollow>();
            if (coinFollow != null)
            {
                coinFollow.StartFollwing(character);
            }
        }
    }
}
