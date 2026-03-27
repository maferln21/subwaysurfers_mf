using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
   private Rigidbody characterRigidbody;
   [SerializeField]
   private CharacterData characterData;
   [SerializeField]
   private Animator characterAnimator;
   [SerializeField]
   private float jumpForce = 10f;
   public float JumpForce
    {
        get { return jumpForce;}
        set { jumpForce = value; }
    }
   [SerializeField]
   private float distanceToMove = 2f;
   [SerializeField]
   private float moveDuration = 0.2f;
   [SerializeField]
   private Transform characterStartPivot;
   [SerializeField]
   private UnityEvent onJump;
   [SerializeField]
   private UnityEvent onMoveToSide;
   [SerializeField]
   private UnityEvent onRoll;
   [SerializeField]
   private Collider normalCollider;
   [SerializeField]
   private Collider rollcollider;
    [SerializeField]
    private float RightLimit;
     [SerializeField]
     private float LeftLimit;
   private bool isGrounded = true;
   private bool isMoving = false;
   private bool isRolling = false;
   private bool isActive = false;
   private bool isFlying = false;
   public bool  IsFlying
    {
        get {return isFlying; }
        set { isFlying = value; }
    }
    public CharacterData CharacterData => characterData;
    public Rigidbody CharacterRigidbody => characterRigidbody;
    public Animator CharacterAnimator => characterAnimator;
    public bool IsActive => isActive;
    public void PlayGroundAnimation(string animationName)
    {
        if (isFlying) return;
        characterAnimator.Play(animationName, 0, 0f);

    }

   private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }
   public void StartGame()
    {
        normalCollider.enabled = true;
        rollcollider.enabled = false;
        isRolling = false;
        isMoving = false;
        isActive = true;
        characterAnimator.Play(characterData.jumpAnimationName, 0, 0f);
        transform.position = characterStartPivot.position;
    }
    public void Lose()
    {
        isActive = false;
        StopAllCoroutines();
        characterAnimator.Play(characterData.loseAnimationName, 0, 0f);
    }
    public void Jump()
    {
        if (!isActive || isFlying) return;
        if (isGrounded)
        {
            onJump?.Invoke();
            PlayGroundAnimation(characterData.jumpAnimationName);
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void MoveDown()
    {
        if (!isActive || isRolling || isFlying) return;
        if (!isGrounded)
        {
            characterRigidbody.AddForce(Vector3.down*jumpForce*2,ForceMode.Impulse);
        }
        PlayGroundAnimation(characterData.rollAnimationName);
        onRoll?.Invoke();
        isRolling = true;
        normalCollider.enabled = false;
        rollcollider.enabled = true;
        StartCoroutine(ResetRoll());
    }
    public void MoveLeft()
    {
        if (transform.position.x <= LeftLimit) return;
       Move(Vector3.left);
    }
    public void MoveRight()
    {
        if (transform.position.x >= RightLimit) return;
        Move(Vector3.right);
    }
    private void Move(Vector3 direction)
    {
        if(isMoving || !isActive) return;
        onMoveToSide?.Invoke();
        PlayGroundAnimation(characterData.moveAnimationName);
        isMoving = true;
        Vector3 targetPosition = transform.position + direction * distanceToMove;
 
        transform.DOMove(targetPosition,moveDuration).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            isMoving =false;
        });
    }
    private IEnumerator ResetRoll()
    {
        yield return null;
        yield return new WaitForSeconds(characterAnimator.GetCurrentAnimatorStateInfo(0).length);
        isRolling = false;   
        normalCollider.enabled = true;
        rollcollider.enabled = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (isActive && collision.gameObject.CompareTag("Ground"))
        {
            if (!isRolling)
            {
                characterAnimator.Play(characterData.runAnimationName, 0, 0f);
            }
            isGrounded = true;
        }
    }
}