using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private string pauseMenuOpenAnimation = "Show";
    [SerializeField]
    private string pauseMenuCloseAnimation = "Hide";
    [SerializeField]
    private Animator pauseMenuAnimator;
    private bool isPaused = false;
    public void PauseGame()
    {
        if (isPaused) return;
        Time.timeScale = 0f;
        pauseMenuAnimator.Play(pauseMenuOpenAnimation, 0, 0f); 
        isPaused = true;
    }
    public void ResumeGame()
    {
         if (isPaused) return;
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuAnimator.Play(pauseMenuCloseAnimation, 0, 0f);
    }
}
