using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] coins;
    private void onEnable()
    {
        ActivateCoins();
    }
    private void ActivateCoins()
    {
        foreach (var coin in coins)
        {
        coin.SetActive(true);
        }
    }
}
