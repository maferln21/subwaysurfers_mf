using UnityEngine;
using System.Collections;

public class JumpPowerUp : MonoBehaviour
{
    [SerializeField]
    private float jumpForceMultiplier = 1.5f;
    [SerializeField]
    private float duration = 5f;
    [SerializeField]
    private GameObject[] boots;
    [SerializeField]
    private  Character character;
    private float originalJumpForce;
    private Coroutine powerUpCoroutine;
    private void Awake()
    {
        originalJumpForce = character.JumpForce;
    }
    public void Activate()
    {
        originalJumpForce = character.JumpForce;
        character.JumpForce *= jumpForceMultiplier;
        powerUpCoroutine = StartCoroutine(DeactivateAfterDuration());
    }
    private void ActivateBoots(bool isActive)
    {
        foreach (var boot in boots)
        {
            boot.SetActive(isActive);
        }
    }
    private IEnumerator DeactivateAfterDuration()
    {
        ActivateBoots(true);
        yield return new WaitForSeconds(duration);
        character.JumpForce = originalJumpForce;
        ActivateBoots(false);
    }  
    public void Deactivate()
    {
        if (powerUpCoroutine != null)
        {
            StopCoroutine(powerUpCoroutine);
            powerUpCoroutine = null;
        }
        character.JumpForce = originalJumpForce;
        ActivateBoots(false);
    }
}
