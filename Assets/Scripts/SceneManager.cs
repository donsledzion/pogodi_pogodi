using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] CanvasGroup cg;
    [SerializeField] private float fadeSpeed;
    private bool fadeStarted;
    public void RestartLevel()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0) return;        
        GameManager.Instance.ResetStats();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void LoadGameScene()
    {
        StartCoroutine(FadeInToGame());        
    }

    IEnumerator FadeInToGame()
    {
        AudioController.Loop(false);
        float volumeLevel = AudioController.GetVolume();
        if (fadeStarted)
            yield break;
        fadeStarted = true;
        while (cg.alpha > 0)
        {
            AudioController.SetVolume(cg.alpha * volumeLevel);
            cg.alpha -= fadeSpeed * Time.deltaTime;

            yield return null;
        }
        AudioController.StopPlaying();
        AudioController.SetVolume(1f);
        AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainGame");
        ao.allowSceneActivation = false;
        while (ao.isDone == false)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

