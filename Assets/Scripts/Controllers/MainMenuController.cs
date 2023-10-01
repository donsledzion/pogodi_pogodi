using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private float tweenTime;
    [SerializeField] private Transform mainMenuTransform;

    [ContextMenu("Hide Main Menu Instantly ")]
    public void HideMainMenuInstantly()
    {
        mainMenuTransform.localScale = Vector3.zero;
    }

    [ContextMenu("Tween Up Main Menu")]
    public void TweenUpMainMenu()
    {
        mainMenuTransform.localScale = Vector3.zero;
        LeanTween.scale(mainMenuTransform.gameObject, Vector3.one, tweenTime).setEaseOutElastic();
    }

    public void TweenUpHighScores()
    {
        Debug.Log("Clicked high scores button");
    }

    public void TweenUpSettings()
    {
        Debug.Log("Clicked settings button");
    }

    public void TweenUpHowToPlay()
    {
        Debug.Log("Clicked how to play button");
    }
}
