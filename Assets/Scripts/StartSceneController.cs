using UnityEngine;
using TMPro;
public class StartSceneController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTMP;
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        if (highScore > 0)
            scoreTMP.text = "HIGH SCORE: " + highScore.ToString();
        else
            scoreTMP.gameObject.SetActive(false);
    }
}
