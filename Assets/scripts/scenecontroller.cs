using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenecontroller : MonoBehaviour
{
    [SerializeField]
    private Animator fade;
    [SerializeField]
    private string fadeAnimationName;

    public void GoToSeneneWithFade(string sceneName)
    {
        StartCoroutine(LoadSceneAfterFde(sceneName));
    }
    
    private IEnumerator LoadSceneAfterFde(string sceneName)
    {
        fade.Play(fadeAnimationName, 0, 0f);
        yield return new WaitForSeconds(fade.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(sceneName);
    }
}
