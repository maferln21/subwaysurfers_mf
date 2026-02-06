 using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
     [SerializeField]
   private Transform platformsPivot;
   [SerializeField]
   private InstantiatePoolObjects[] platformPrefabs;
   [SerializeField]
    private int initialPlatforms = 10;
    [SerializeField]
    private float speed = 5f;
    private bool isRunning = true;
    private GameObject lastPlatform;
    public void StartGame()
    {
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
    }
    public void InitiatePlatform(int number)
    {
        for (int i=  0; i < number; i++)
        {
            InstantiatePoolObjects instantiatePool = platformPrefabs[Random.Range(0,platformPrefabs.Length)];
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform !=null)
            {
                spawnPosition = lastPlatform.transform.localPosition + lastPlatform.GetComponent<Collider>().bounds.size.z*Vector3.forward * 0.4f;
            }
            instantiatePool.InstantiateObject(spawnPosition);
            GameObject newPlatform = instantiatePool.GetCurrentObject();
            newPlatform.transform.SetParent( transform);
            newPlatform.transform.localPosition = spawnPosition + newPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.4f;
            lastPlatform = newPlatform;
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
