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
    private Coroutine deactivateCoroutine;
    public void Activate()
    {
        magnet.SetActive(true);
        magnetCollider.enabled = true;
        if (deactivateCoroutine != null)
        {
            StopCoroutine(deactivateCoroutine);
        }
        deactivateCoroutine = StartCoroutine(DeactivateAfterDuration());
    }
    public void Deactivate()
    {
        if( deactivateCoroutine != null)
        {
            StopCoroutine(deactivateCoroutine);
            deactivateCoroutine = null;
        }
        magnet.SetActive(false);
        magnetCollider.enabled = false;
    }
    private IEnumerator DeactivateAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        Deactivate();
    }
}
