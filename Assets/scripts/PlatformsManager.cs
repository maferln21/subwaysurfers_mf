 using UnityEngine;
 using UnityEngine.Events;
public class PlatformsManager : MonoBehaviour
{
     [SerializeField]
   private Transform platformsPivot;
   [SerializeField]
   private InstantiatePoolObjects[] platformPrefabs;
   [SerializeField]
   private InstantiatePoolObjects[] securePlatformPrefabs;
   [SerializeField]
    private int initialPlatforms = 10;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private UnityEvent<Platform> onPlatformPassed;
    private bool isRunning = true;
    private GameObject lastPlatform;
    private int  platformsInstantiated = 0;
    public void StartGame()
    {
        lastPlatform = null;
        platformsInstantiated = 0;
        InitializePlatforms();
        InitiatePlatform(initialPlatforms);
        transform.position = platformsPivot.position;
        isRunning = true;
    }
    public void InitializePlatforms()
    {
        foreach (var plataform in platformPrefabs)
        {
            plataform.DeactivateAllObjects();
        }
        foreach (var securePlatform in securePlatformPrefabs)
        {
            securePlatform.DeactivateAllObjects();
        }
    }
    public void InitiatePlatform(int number)
    {
        for (int i=  0; i < number; i++)
        {
            InstantiatePoolObjects instantiatePool;
            if (platformsInstantiated < 2)
            {
                instantiatePool = securePlatformPrefabs[Random.Range(0, securePlatformPrefabs.Length)];
            }else
            {
                instantiatePool = platformPrefabs[Random.Range(0, platformPrefabs.Length)]; 
            }
            platformsInstantiated++;
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform !=null)
            {
                spawnPosition = lastPlatform.transform.localPosition + lastPlatform.GetComponent<Platform>().ColliderSize*Vector3.forward;
            }
            instantiatePool.InstantiateObject(spawnPosition);
            GameObject createdPlatform = instantiatePool.GetCurrentObject();
            Platform newPlatform = createdPlatform.GetComponent<Platform>();
            newPlatform.transform.SetParent(transform);
            newPlatform.transform.localPosition = spawnPosition + newPlatform.ColliderSize * Vector3.forward;
            lastPlatform = newPlatform.gameObject;
            onPlatformPassed?.Invoke(newPlatform);
        }
    }
    private void Update()
    {
    if (isRunning)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }    
    }

    public void StopPlatforms()
    {
        isRunning = false;
    }
}
