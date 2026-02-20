using UnityEngine;
using UnityEngine.Events;

public class CoinsManager : MonoBehaviour
{
    private int coins;
    [SerializeField]
    private UnityEvent<string> onCoinsChanged;
    private void Awake()
    {
        coins = 0;
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        onCoinsChanged.Invoke(coins.ToString());
    }
    public void SetCoins(int amount)
    {
        coins = amount;
        onCoinsChanged.Invoke(coins.ToString());
    }
}
