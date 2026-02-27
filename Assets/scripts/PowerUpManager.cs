using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    private int minPlatformsNumber = 5;
    [SerializeField]
    private int maxPlatformsNmber = 7;
    [SerializeField]
    private InstantiatePoolObjects[] powerUpPools;
    [SerializeField]
    private float powerUpOffset = 2f;
    private int platformsNumber;
    private int platformsCounter = 0;
    public void Awake()
    {
        SetPlatformsNumber();
    }
    private void SetPlatformsNumber()
    {
        platformsNumber = Random.Range(minPlatformsNumber, maxPlatformsNmber);
    }
    public void PlatformPassed(Platform platform)
    {
        platformsCounter++;
        if (platformsCounter >= platformsNumber)
        {
            SpawnPoweUp(platform);
            platformsCounter = 0;
            SetPlatformsNumber();
        }
    }
    private void SpawnPoweUp(Platform platform)
    {
        InstantiatePoolObjects pool = powerUpPools[Random.Range(0, powerUpPools.Length)];
        pool.InstantiateObject(Vector3.zero);
        GameObject powerUp = pool.GetCurrentObject();
        powerUp.transform.localPosition += Vector3.up * powerUpOffset;
        platform.AddPowerUp(powerUp);
    }
}
