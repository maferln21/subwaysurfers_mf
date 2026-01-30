 using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
     [SerializeField]
   private Transform platformsPivot;
   [SerializeField]
   private GameObject[] platformPrefabs;
   [SerializeField]
    private int initialPlatforms = 5;
    [SerializeField]
    private float speed = 5f;
    private bool isRunning = true;
    private GameObject lastPlatform;
    private void Start()
    {
        InitiatePlatform(initialPlatforms);
        transform.position = platformsPivot.position;
    }
    public void InitiatePlatform(int number)
    {
        for (int i=  0; i < number; i++)
        {
            GameObject platformPrefab = platformPrefabs[Random.Range(0,platformPrefabs.Length)];
            Vector3 spawnPosition = Vector3.zero;
            if (lastPlatform !=null)
            {
                spawnPosition = lastPlatform.transform.localPosition + lastPlatform.GetComponent<Collider>().bounds.size.z*Vector3.forward * 0.5f;
            }
            GameObject newPlatform = Instantiate(platformPrefab, Vector3.zero,Quaternion.identity, transform);
            newPlatform.transform.localPosition = spawnPosition + newPlatform.GetComponent<Collider>().bounds.size.z * Vector3.forward * 0.5F;
            lastPlatform = newPlatform;
        }
    }
    private void Update()
    {
    if (isRunning)
        {
            platformsPivot.Translate(Vector3.back * speed * Time.deltaTime);
        }    
    }

}
