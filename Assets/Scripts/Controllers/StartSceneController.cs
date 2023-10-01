using UnityEngine;
using TMPro;
public class StartSceneController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private Transform welcomeScreenTransform;
    [SerializeField] private MainMenuController mainMenuController;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        if (highScore > 0)
            scoreTMP.text = "HIGH SCORE: " + highScore.ToString();
        else
            scoreTMP.gameObject.SetActive(false);
    }

    [ContextMenu("Swap To Main Menu")]
    public void SwapToMainMenu()
    {
        LeanTween.scale(welcomeScreenTransform.gameObject, Vector3.zero, 1f)
            .setEaseInElastic()
            .setOnComplete(() =>
            {
                mainMenuController.TweenUpMainMenu();
                welcomeScreenTransform.gameObject.SetActive(false);
            });
    }


}
