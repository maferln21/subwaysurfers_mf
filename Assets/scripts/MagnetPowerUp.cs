using UnityEngine;
using System.Collections;

public class MagnetPowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject magnet;
    [SerializeField]
    private float duration = 5f;
    [SerializeField]
    private Collider magnetCollider;
    public void Active()
    {
        magnet.SetActive(true);
        magnetCollider.enabled = true;
        StartCoroutine (DeactivateAfterDuration());
    }
    private IEnumerator DeactivateAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        magnet.SetActive(false);
        magnetCollider.enabled = false;
    }
}
