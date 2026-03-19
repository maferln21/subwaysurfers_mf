using UnityEngine;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] coins;
    private List<GameObject> powerUps = new List<GameObject>();
    private float colliderSize;
    public float ColliderSize => colliderSize;
    private void Awake()
    {
        colliderSize = GetComponent<Collider>().bounds.size.z * 0.5f;
    }
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
    public void AddPowerUp(GameObject powerUp)
    {
        if (coins.Length == 0) return;
        GameObject randomCoin = coins[Random.Range(0, coins.Length)];
        randomCoin.SetActive(false);
        powerUp.transform.SetParent(transform);
        powerUp.transform.localPosition = randomCoin.transform.localPosition;
        powerUps.Add(powerUp);
    }
    private void OnDisable()
    {
        foreach (var powerUp in powerUps)
        {
            powerUp.SetActive(false);
        }
        powerUps.Clear();
    }
}
