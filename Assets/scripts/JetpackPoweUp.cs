using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;

public class JetpackPoweUp : MonoBehaviour
{
    [SerializeField]
    private float flyingHeight = 4.5f;
    [SerializeField]
    private Character character;
    [SerializeField]
    private GameObject jetPackAsset;
    [SerializeField]
    private float flyDuration = 5f;
    [SerializeField]
    private UnityEvent onJetpackActived;
    private Coroutine flyCoroutine;
    private void Awake()
    {
        jetPackAsset.SetActive(false);
    }
    public void Activate()
    {
        if (!character.IsActive || character.IsFlying) return;
        character.IsFlying = true;
        jetPackAsset.SetActive(true);
        onJetpackActived?.Invoke();
        character.CharacterRigidbody.isKinematic = true;
        character.transform.DOMoveY(flyingHeight, 1f).SetEase(Ease.OutQuad);
        character.CharacterAnimator.Play(character.CharacterData.flyAnimationName);
        flyCoroutine = StartCoroutine(DeactivateJetPack());
    }
    private IEnumerator DeactivateJetPack()
    {
        yield return new WaitForSeconds(flyDuration);
        Deactivate();
    }
    public void Deactivate()
    {
        if (flyCoroutine != null)
        {
            StopCoroutine(flyCoroutine);
            flyCoroutine = null;
        }
        character.IsFlying = false;
        jetPackAsset.SetActive(false);
        character.CharacterAnimator.Play(character.CharacterData.jumpAnimationName);
    }
}
