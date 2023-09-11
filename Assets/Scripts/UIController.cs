using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP, _summaryScoreTMP, _highScoreTMP;
    [SerializeField] private GameObject[] _failIcons;
    [SerializeField] private GameObject _GameOverPanel;
    [SerializeField] private GameObject _newHighScoreGO;
    [SerializeField] private GameObject _hurryUp;

    private void Start()
    {
        GameManager.Instance.RegisterUICOntroller(this);
    }

    public void UpdateScore(int score)
    {
        if(score < 0) return;
        _scoreTMP.text = "SCORE: " + score.ToString();
    }

    public void ResetFails()
    {
        foreach(GameObject go in _failIcons)
        {
            go.SetActive(false);
        }
    }

    public void UpdateFails(int failsCount)
    {

        if (failsCount <= 0) return;
        if (failsCount > _failIcons.Length) return;
        _failIcons[failsCount - 1].SetActive(true);
    }

    public void GameOver(int playerScore, bool newHighScore = false)
    {
        ResetFails();
        _GameOverPanel.SetActive(true);
        _scoreTMP.gameObject.SetActive(false);
        _summaryScoreTMP.text = "YOUR SCORE: " + playerScore.ToString();
        _newHighScoreGO.SetActive(newHighScore);
        _highScoreTMP.gameObject.SetActive(!newHighScore);
        if (!newHighScore)
        {
            _highScoreTMP.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highScore", 0).ToString();              
        }
    }

    public void HurryUp()
    {
        _hurryUp.gameObject.SetActive(true);
    }
}
